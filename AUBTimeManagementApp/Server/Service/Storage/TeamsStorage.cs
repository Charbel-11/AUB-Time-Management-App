using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Server.DataContracts;
using Server.Service.Storage;

namespace AUBTimeManagementApp.Service.Storage {
    class TeamsStorage {
        #region Add
        /// <summary>
        /// Adds a new team to the database
        /// </summary>
        /// <returns>The unique teamID of the created team, -1 if it was unsuccessful</returns>
        public static int AddTeam(string teamName) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO Teams(TeamName) " +
                                "VALUES (@TeamName)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamName", SqlDbType.NVarChar).Value = teamName;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear();
                query = "SELECT LAST TeamID FROM Teams";
                command = new SqlCommand(query, sqlConnection);
                dataReader = command.ExecuteReader();

                int teamID = dataReader.Read() ? dataReader.GetInt32(0) : -1;
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return teamID;
            }
            catch (SqlException exception) { Console.WriteLine("AddTeam: " + exception.Message); throw; }
        }

        /// <summary>
        /// Adds a member or more to the team
        /// </summary>
        public static void AddTeamMembers(int teamID, List<string> usernames) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                foreach (string username in usernames) {
                    string query = "INSERT INTO isMember(Username, TeamID) " +
                                    "VALUES (@Username, @TeamID)";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                    command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                    SqlDataReader dataReader = command.ExecuteReader();

                    command.Parameters.Clear(); dataReader.Close();
                }
                sqlConnection.Close();
            } catch(SqlException exception) { Console.WriteLine("AddTeamMembers: " + exception.Message); throw; }
        }

        /// <summary>
        /// Adds an admin to the team (from the existing members)
        /// </summary>
        public static void AddTeamAdmin(int teamID, string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isAdmin(Username, TeamID) " +
                                "VALUES (@Username, @TeamID)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
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
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM isMember WHERE Username = @Username AND TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return true;
            }
            catch (SqlException exception) { Console.WriteLine("removeTeamMember: " + exception.Message); throw; }   
        }

        /// <summary>
        /// Sets an admin to be a usual member
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public static bool removeTeamAdmin(int teamID, string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM isAdmin WHERE Username = @Username AND TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return true;
            }
            catch (SqlException exception) { Console.WriteLine("removeTeamAdmin: " + exception.Message); throw; }
        }
        #endregion

        #region Get

        public static string getTeamName(int teamID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT TeamName FROM Teams WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                string teamName = dataReader.Read() ? dataReader.GetString(0) : "";
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return teamName;
            }
            catch (SqlException exception) { Console.WriteLine("getTeamName: " + exception.Message); throw; }
        }

        public static List<int> getUserTeams(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT TeamID FROM isMember WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> teams = new List<int>();
                while (dataReader.Read()) { teams.Add(dataReader.GetInt32(0)); }

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return teams;
            }
            catch (SqlException exception) { Console.WriteLine("getUserTeams: " + exception.Message); throw; }
        }

        /// <summary>
        /// Gets a list of the members of a team
        /// </summary>
        /// <returns>The usernames of each member</returns>
        public static List<string> getTeamMembers(int teamID) {
            try  {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT Username FROM isMember WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<string> members = new List<string>();
                while (dataReader.Read()) { members.Add(dataReader.GetInt32(0).ToString()); }
                
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return members;
            }
            catch (SqlException exception) { Console.WriteLine("getTeamMembers: " + exception.Message); throw; }
        }

        public static List<string> getTeamAdmins(int teamID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT Username FROM isAdmin WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<string> admins = new List<string>();
                while (dataReader.Read()) { admins.Add(dataReader.GetInt32(0).ToString()); }
               
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return admins;
            }
            catch (SqlException exception) { Console.WriteLine("getTeamAdmins: " + exception.Message); throw; }
        }
        #endregion
    }
}
