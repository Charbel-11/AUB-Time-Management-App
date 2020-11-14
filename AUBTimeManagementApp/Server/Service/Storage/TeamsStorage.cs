using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class TeamsStorage
    {
        #region Add
        /// <summary>
        /// Adds a new team to the database
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool addTeam(string teamName, string admin, int teamID, string[] members) {
            return true;
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

        public static int getNewTeamID() {
            return 1;
        }
        #endregion
    }
}
