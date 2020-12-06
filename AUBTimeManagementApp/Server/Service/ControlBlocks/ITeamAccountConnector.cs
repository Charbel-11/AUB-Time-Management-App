using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface ITeamAccountConnector {

        /// <summary>
        /// Checks for the validity of usernames, creates a new teams using the valid usernames and notifies online users
        /// </summary>
        /// <param name="ConnectionID">The connection ID of the calling user</param>
        /// <param name="admin">The admin of the team</param>
        /// <param name="teamName">The name of the team</param>
        /// <param name="members">A list of usernames to be checked for validity</param>
        void createTeam(int ConnectionID, string admin, string teamName, List<string> members);

        
        /// <summary>
        /// Adds a member to the team and notifies online users (if the username is valid)
        /// </summary>
        /// <param name="ConnectionID">Connection ID of the calling user, needed to give feedback</param>
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToAdd">Username of the user to add to the team</param>
        void addMember(int ConnectionID, int teamID, string userToAdd);
    }
}
