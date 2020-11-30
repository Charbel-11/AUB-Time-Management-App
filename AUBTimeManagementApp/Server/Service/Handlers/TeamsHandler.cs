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
        public void CreateTeamRequest(int ConnectionID, string admin, string teamName, List<string> members) 
        {
            List<string> invalidUsernames = new List<string>();
            List<string> validUsernames = new List<string>();

            validUsernames.Add(admin);
            foreach (string m in members) {
                if (AccountsStorage.usernameExists(m)) { validUsernames.Add(m); }
                else { invalidUsernames.Add(m); }
            }

            int teamID = TeamsStorage.AddTeam(teamName);
            TeamsStorage.AddTeamMembers(teamID, validUsernames);
            TeamsStorage.AddTeamAdmin(teamID, admin);
            ServerTCP.PACKET_CreateTeamReply(ConnectionID, teamID != -1, invalidUsernames);
            if (teamID == -1) { return; }

            //Send the team details to online users         
            foreach (string user in validUsernames) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_NewTeamCreated(cID, teamName, teamID, new string[] { admin }, validUsernames.ToArray());
            }
        }

        private Team getTeamInfo(int teamID) {
            string teamName = TeamsStorage.getTeamName(teamID);
            List<string> members = TeamsStorage.getTeamMembers(teamID);
            List<string> admins = TeamsStorage.getTeamAdmins(teamID);
            return new Team(teamID, teamName, admins, members);
        }
               
        /// <summary>
        /// Adds a member to the team and notifies online users (if the username is valid)
        /// </summary>
        /// <param name="ConnectionID">Connection ID of the calling user, needed to give feedback</param>
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToAdd">Username of the user to add to the team</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool AddMemberRequest(int ConnectionID, int teamID, string userToAdd)
        {
            bool OK = AccountsStorage.usernameExists(userToAdd);
            if (OK) {
                TeamsStorage.AddTeamMembers(teamID, new List<string> { userToAdd });
                OK = true;
            }
            ServerTCP.PACKET_AddMemberReply(ConnectionID, teamID, OK);
            if (!OK) { return false; }

            List<string> teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string user in teamMembers) {
                if (user == userToAdd) { continue; }
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_MemberAdded(cID, teamID, userToAdd);
            }

            Team curTeam = getTeamInfo(teamID);
            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToAdd, out int ID))
                ServerTCP.PACKET_NewTeamCreated(ID, curTeam.teamName, teamID, curTeam.teamAdmin.ToArray(), curTeam.teamMembers.ToArray());

            return true;
        }
        
        /// <summary>
        /// Removes a member from a team
        /// </summary>
        /// No need for feedback since the username must be correct (it was taken from the GUI)
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToRemove">Username of the member to remove</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool RemoveMemberRequest(int teamID, string userToRemove)
        {
            bool b = TeamsStorage.removeTeamMember(teamID, userToRemove);
            if (!b) { return false; }

            List<string> teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string member in teamMembers) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(member, out int cID))
                    ServerTCP.PACKET_MemberRemoved(cID, teamID, userToRemove);
            }

            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToRemove, out int ID))
                ServerTCP.PACKET_MemberRemoved(ID, teamID, userToRemove);

            return true;
        }

        /// <summary>
        /// Either sets a user to become an admin, or makes him a member again
        /// </summary>
        /// <param name="teamID">ID of the team</param>
        /// <param name="username">Username of the user which will have his admin state changed</param>
        /// <param name="isNowAdmin">True if we want to set the user as admin, false otherwise</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool ChangeAdminState(int teamID, string username, bool isNowAdmin) {
            bool b = false;
            if (isNowAdmin) {
                TeamsStorage.AddTeamAdmin(teamID, username);
                b = true;
            }
            else { b = TeamsStorage.removeTeamAdmin(teamID, username); }
            if (!b) { return false; }

            List<string> teamMembers = TeamsStorage.getTeamMembers(teamID);
            foreach (string member in teamMembers) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(member, out int cID))
                    ServerTCP.PACKET_NewAdminState(cID, teamID, username, isNowAdmin);
            }
            return true;
        }

        /// <summary>
        /// Returns teams event with specific priorities
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="low">True if we want low priority events</param>
        /// <param name="mid">True if we want mid priority events</param>
        /// <param name="high">True if we want high priority events</param>
        /// <returns>A list of event IDs of the corresponding events</returns>
        public List<int> getFilteredTeamEvents(int teamID, bool low, bool mid, bool high)
        {
            List<int> events = new List<int>();
            if (low) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 1)); }
            if (mid) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 2)); }
            if (high) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 3)); }
            return events;
        }

        /// <summary>
        /// Gets all the teams that a user belongs to
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The list of the teams that the user belongs to</returns>
        public List<Team> GetUserTeams(string username) {
            List<int> teamsID = TeamsStorage.getUserTeams(username);
            List<Team> teams = new List<Team>();

            foreach (int ID in teamsID) {
                teams.Add(getTeamInfo(ID));
            }

            return teams;
        }

        /// <summary>
        /// Gets all the members of a specific team
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <returns></returns>
        public List<string> GetTeamMembers(int teamID)
        {
            return new List<string> (TeamsStorage.getTeamMembers(teamID));
        }
    }
}
