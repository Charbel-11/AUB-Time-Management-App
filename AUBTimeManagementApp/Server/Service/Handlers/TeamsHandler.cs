using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;

namespace Server.Service.Handlers
{
    public class TeamsHandler: ITeamsHandler
    {
        /// <summary>
        /// Creates a new team in the database and notifies all online users
        /// </summary>
        /// <param name="admin">The admin of the team (calling user)</param>
        /// <param name="teamName">The name of the team</param>
        /// <param name="members">The list of members given by the calling user (might be invalid)</param>
        public void CreateTeamRequest(int ConnectionID, string admin, string teamName, string[] members)
        {
            List<string> invalidUsernames = new List<string>();
            List<string> validUsernames = new List<string>();

            validUsernames.Add(admin);
            foreach(string m in members) {
                if (AccountsStorage.usernameExists(m)) { validUsernames.Add(m); }
                else { invalidUsernames.Add(m); }
            }

            int teamID = TeamsStorage.addTeam(teamName, admin, validUsernames.ToArray());
            ServerTCP.PACKET_CreateTeamReply(ConnectionID, teamID != -1, invalidUsernames.ToArray());
            if (teamID == -1) { return; }

            //Send the team details to online users         
            foreach (string user in validUsernames) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_NewTeamCreated(cID, teamName, teamID, new string[] { admin }, validUsernames.ToArray());
            }
        }
               
        public bool AddMemberRequest(int ConnectionID, int teamID, string userToAdd)
        {
            bool OK = AccountsStorage.usernameExists(userToAdd);
            if (OK) { OK = TeamsStorage.addTeamMember(teamID, userToAdd); }
            ServerTCP.PACKET_AddMemberReply(ConnectionID, OK);
            if (!OK) { return false; }

            string[] teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string user in teamMembers) {
                if (user == userToAdd) { continue; }
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_MemberAdded(cID, teamID, userToAdd);
            }

            Team curTeam = TeamsStorage.getTeamInfo(teamID);
            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToAdd, out int ID))
                ServerTCP.PACKET_NewTeamCreated(ID, curTeam.teamName, teamID, curTeam.teamAdmin.ToArray(), curTeam.teamMembers.ToArray());

            return true;
        }

        public bool RemoveMemberRequest(int teamID, string userToRemove)
        {
            bool b = TeamsStorage.removeTeamMember(teamID, userToRemove);
            if (!b) { return false; }

            string[] teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string member in teamMembers) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(member, out int cID))
                    ServerTCP.PACKET_MemberRemoved(cID, teamID, userToRemove);
            }

            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToRemove, out int ID))
                ServerTCP.PACKET_MemberRemoved(ID, teamID, userToRemove);

            return true;
        }

        public bool ChangeAdminState(int teamID, string username, bool isNowAdmin) {
            bool b = false;
            if (isNowAdmin) { b = TeamsStorage.addTeamAdmin(teamID, username); }
            else { b = TeamsStorage.removeTeamAdmin(teamID, username); }
            if (!b) { return false; }

            string[] teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string member in teamMembers) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(member, out int cID))
                    ServerTCP.PACKET_NewAdminState(cID, teamID, username, isNowAdmin);
            }
            return true;
        }

        public List<Team> GetPersonalTeams(string username)
        {
            List<int> teamsID = AccountsStorage.getUserTeams(username);
            List<Team> teams = new List<Team>();

            foreach(int ID in teamsID) {
                teams.Add(TeamsStorage.getTeamInfo(ID));
            }

            return teams;
        }


        public List<int> getTeamEvents(int teamID, bool low, bool mid, bool high)
        {
            List<int> events = new List<int>();
            if (low) { events.AddRange(TeamsStorage.getTeamEvents(teamID, 1)); }
            if (mid) { events.AddRange(TeamsStorage.getTeamEvents(teamID, 2)); }
            if (high) { events.AddRange(TeamsStorage.getTeamEvents(teamID, 3)); }
            return events;
        }
    }
}
