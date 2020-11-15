using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Server.DataContracts;

namespace AUBTimeManagementApp.Service.Storage
{
    class TeamsStorage
    {
        #region Add
        /// <summary>
        /// Adds a new team to the database
        /// </summary>
        /// <returns>The unique teamID of the created team, -1 if it was unsuccessful</returns>
        public static int addTeam(string teamName, string admin, string[] members) {
            return 0;
        }

        /// <summary>
        /// Adds a member to the team
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool addTeamMember(int teamID, string username) {
            return true;
        }

        /// <summary>
        /// Adds an admin to the team (from the existing members)
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool addTeamAdmin(int teamID, string username) {
            return true;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the team from the databasse
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeam(int teamID) {
            return true;
        }

        /// <summary>
        /// Removes a member from the team
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeamMember(int teamID, string username) {
            return true;
        }

        /// <summary>
        /// Removes an admin from the team
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeamAdmin(int teamID, string username) {
            return true;
        }
        #endregion

        #region Get
        /// <summary>
        /// Gets a list of the members of a team
        /// </summary>
        /// <returns>The usernames of each member (make it ID instead?)</returns>
        public static string[] getTeamMembers(int teamID) {
            return new string[] { "q" };
        }

        public static Team getTeamInfo(int teamID) {
            return new Team(0, "testTeam");
        }
        #endregion
    }
}
