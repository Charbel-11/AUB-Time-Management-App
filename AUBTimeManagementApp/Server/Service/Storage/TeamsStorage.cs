using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Server.DataContracts;
using Server.Service.Storage;

namespace AUBTimeManagementApp.Service.Storage
{
    class TeamsStorage
    {
        #region Add
        /// <summary>
        /// Adds a new team to the database
        /// </summary>
        /// <returns>The unique teamID of the created team, -1 if it was unsuccessful</returns>
        public void AddTeam(string teamName) 
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO Teams(TeamID, TeamName) " +
                                "VALUES (@TeamID, @TeamName)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamName.GetHashCode();
                command.Parameters.Add("@TeamName", SqlDbType.NVarChar).Value = teamName;
               
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close(); 
            }
            catch (SqlException exception) { Console.WriteLine("AddTeam: " + exception.Message); throw; }
        }

        /// <summary>
        /// Adds a member to the team
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public void AddTeamMembers(int teamID, List<string> members) 
        {
            foreach (string member in members)
            {
                try
                {
                    string connectionString = ConnectionUtil.connectionString;
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    string query = "INSERT INTO isMember(UserID, TeamID) " +
                                    "VALUES (@UserID, @TeamID)";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = member.GetHashCode();
                    command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;

                    SqlDataReader dataReader = command.ExecuteReader();

                    command.Parameters.Clear(); sqlConnection.Close();
                }
                catch (SqlException exception) { Console.WriteLine("AddTeamMember: " + exception.Message); throw; }
            }
        }

        /// <summary>
        /// Adds an admin to the team (from the existing members)
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public void  AddTeamAdmin(int teamID, string username)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isAdmin(UserID, TeamID) " +
                                "VALUES (@UserID, @TeamID)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = username.GetHashCode();
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;

                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddTeamAdmin: " + exception.Message); throw; }
        }
    
        #endregion

        #region Remove
        /// <summary>
        /// Removes a member from the team
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeamMember(int teamID, string username) {
            //If the team is now empty, remove team
            return true;
        }

        /// <summary>
        /// Sets an admin to be a usual member
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeamAdmin(int teamID, string username) {
            return true;
        }
        #endregion

        #region Get

        public static List<int> getUserTeams(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                int UserID = username.GetHashCode();
                string query = "SELECT TeamID FROM isMember WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> teams = new List<int>();
                while (dataReader.Read()) { teams.Add(dataReader.GetInt32(0)); }

                sqlConnection.Close(); return teams;
            }
            catch (SqlException exception) { Console.WriteLine("getUserTeams: " + exception.Message); throw; }
        }

        /// <summary>
        /// Gets a list of the members of a team
        /// </summary>
        /// <returns>The usernames of each member</returns>
        public static string[] getTeamMembers(int teamID) {
            return new string[] { "q" };
        }

        public static Team getTeamInfo(int teamID) {

            string teamName = null;
            List<string> members = new List<string>();
            List<string> admins = new List<string>();

            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string query = "SELECT TeamName FROM Teams WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read()) teamName = dataReader.GetString(0);
                sqlConnection.Close();


                connectionString = ConnectionUtil.connectionString;
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT UserID FROM isAdmin WHERE TeamID = @TeamID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                dataReader = command.ExecuteReader();
                while (dataReader.Read()) { admins.Add(dataReader.GetInt32(0).ToString()); }
                sqlConnection.Close();

                connectionString = ConnectionUtil.connectionString;
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT UserID FROM isMember WHERE TeamID = @TeamID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                dataReader = command.ExecuteReader();
                while (dataReader.Read()) { members.Add(dataReader.GetInt32(0).ToString()); }
                sqlConnection.Close();


                return new Team(teamID, teamName, admins, members);
            }
            catch (SqlException exception) { Console.WriteLine("getTeamInfo: " + exception.Message); throw; }


            
        }

        public static List<int> getTeamEvents(int teamID, int priority)
        {
            return null;
        }
        #endregion
    }
}
