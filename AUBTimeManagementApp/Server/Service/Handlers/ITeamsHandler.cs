using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {

        /// <summary>
        /// Adds the new team's information to the database
        /// </summary>
        /// <param name="admin">The admin of the new team</param>
        /// <param name="teamName">The name of the new team</param>
        /// <param name="members">A list of the members of the new team</param>
        /// <returns>The team ID if succesfful, -1 otherwise</returns>
        int CreateTeamRequest(string admin, string teamName, List<string> members);


        /// <summary>
        /// Adds a member to a team
        /// </summary>
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToAdd">Username of the member to add</param>
        void AddMemberRequest(int teamID, string userToAdd);

        /// <summary>
        /// Removes a member from a team
        /// </summary>
        /// No need for feedback since the username must be correct (it was taken from the GUI)
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToRemove">Username of the member to remove</param>
        /// <returns>True if the team becomes empty, false otherwise</returns>
        bool RemoveMemberRequest(int teamID, string userToRemove);

        // Remove team with teamID from the teams storage
        void RemoveTeam(int teamID);


        /// <summary>
        /// Either sets a user to become an admin, or makes him a member again
        /// </summary>
        /// <param name="teamID">ID of the team</param>
        /// <param name="username">Username of the user which will have his admin state changed</param>
        /// <param name="isNowAdmin">True if we want to set the user as admin, false otherwise</param>
        /// <returns>True if successful, false otherwise</returns>
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);

        /// <summary>
        /// Returns teams event with specific priorities
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="low">True if we want low priority events</param>
        /// <param name="mid">True if we want mid priority events</param>
        /// <param name="high">True if we want high priority events</param>
        /// <returns>A list of event IDs of the corresponding events</returns>
        List<int> getFilteredTeamEvents(int teamID, bool low, bool mid, bool high);


        /// <summary>
        /// Gets all the teams that a user belongs to
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The list of the teams that the user belongs to</returns>
        List<Team> GetUserTeams(string username);

        /// <summary>
        /// Gets all the members of a specific team
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <returns>list of usernames of team members</returns>
        List<string> GetTeamMembers(int teamID);
    }
}
