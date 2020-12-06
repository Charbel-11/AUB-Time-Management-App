using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;

namespace Server.Service.Handlers
{
    public class TeamsHandler: ITeamsHandler
    {
        // Create a team gievn an admin username and a list of members usernames
        public int CreateTeamRequest(string admin, string teamName, List<string> members) 
        {
            int teamID = TeamsStorage.AddTeam(teamName);
            if (teamID == -1) { return -1; }
            TeamsStorage.AddTeamMembers(teamID, members);
            TeamsStorage.AddTeamAdmin(teamID, admin);
            return teamID;
        }

        /// <summary>
        /// Returns a Team instance that contains all the information of a team specified by its teamID
        /// </summary>
        /// <param name="teamID">The ID of the team we are querying</param>
        /// <returns>A team instance</returns>
        public Team getTeamInfo(int teamID) {
            string teamName = TeamsStorage.getTeamName(teamID);
            List<string> members = TeamsStorage.getTeamMembers(teamID);
            List<string> admins = TeamsStorage.getTeamAdmins(teamID);
            return new Team(teamID, teamName, admins, members);
        }

        // Add a member to team with teamID
        public void AddMemberRequest(int teamID, string userToAdd)
        {
            TeamsStorage.AddTeamMembers(teamID, new List<string> { userToAdd });
        }

        // Remove user with username userToRemove from team with teamID
        public bool RemoveMemberRequest(int teamID, string userToRemove)
        {
            return TeamsStorage.removeTeamMember(teamID, userToRemove);
        }

        // Remove team with teamID from the teams storage
        public void RemoveTeam(int TeamID)
		{
            TeamsStorage.removeTeam(TeamID);
		}

        // Change the state of a user (admin -> member) or (member -> admin)
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


        // Get a list of events ids for a team with teamID and filter by priority
        public List<int> getFilteredTeamEvents(int teamID, bool low, bool mid, bool high)
        {
            List<int> events = new List<int>();
            if (low) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 1)); }
            if (mid) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 2)); }
            if (high) { events.AddRange(EventsStorage.getFilteredTeamEvents(teamID, 3)); }
            return events;
        }

        // Get a list of team objects where user with username is a member
        public List<Team> GetUserTeams(string username) {
            List<int> teamsID = TeamsStorage.getUserTeams(username);
            List<Team> teams = new List<Team>();

            foreach (int teamID in teamsID) {
                teams.Add(getTeamInfo(teamID));
            }

            return teams;
        }

        // Get a list of members usernames for a given team with teamID
        public List<string> GetTeamMembers(int teamID)
        {
            return new List<string> (TeamsStorage.getTeamMembers(teamID));
        }
    }
}
