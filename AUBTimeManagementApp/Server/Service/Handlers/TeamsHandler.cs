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
        /// Adds the new team's information to the database
        /// </summary>
        /// <param name="admin">The admin of the new team</param>
        /// <param name="teamName">The name of the new team</param>
        /// <param name="members">A list of the members of the new team</param>
        /// <returns>The team ID if succesfful, -1 otherwise</returns>
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
               
        /// <summary>
        /// Adds a member to a team
        /// </summary>
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToAdd">Username of the member to add</param>
        public void AddMemberRequest(int teamID, string userToAdd)
        {
            TeamsStorage.AddTeamMembers(teamID, new List<string> { userToAdd });
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
            return TeamsStorage.removeTeamMember(teamID, userToRemove);
        }

        public void RemoveTeam(int TeamID)
		{
            TeamsStorage.removeTeam(TeamID);
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

            foreach (int teamID in teamsID) {
                teams.Add(getTeamInfo(teamID));
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
