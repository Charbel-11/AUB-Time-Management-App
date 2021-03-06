﻿using System;
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

                command.Parameters.Clear(); dataReader.Close();
                query = "SELECT TOP 1 TeamID FROM Teams ORDER BY TeamID DESC";
                command = new SqlCommand(query, sqlConnection);
                dataReader = command.ExecuteReader();

                int teamID = dataReader.Read() ? dataReader.GetInt32(0) : -1;
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return teamID;
            }
            catch (Exception exception) { Console.WriteLine("AddTeam: " + exception.Message); throw; }
        }

        /// <summary>
        /// Adds a member or more to the team and update number of members in the team
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

                    query = "SELECT Count(*) FROM isMember WHERE TeamID = @TeamID";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@teamID", SqlDbType.Int).Value = teamID;

                    dataReader = command.ExecuteReader();
                    int membersNumber = dataReader.Read() ? dataReader.GetInt32(0) : 0;
                    command.Parameters.Clear(); dataReader.Close();

                    query = "UPDATE Teams SET MembersNumber = @membersNumber WHERE TeamID = @teamID";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@membersNumber", SqlDbType.Int).Value = membersNumber;
                    command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;

                    dataReader = command.ExecuteReader();
                    command.Parameters.Clear(); dataReader.Close();
                }
                sqlConnection.Close();
            } catch(Exception exception) { Console.WriteLine("AddTeamMembers: " + exception.Message); throw; }
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
            catch (Exception exception) { Console.WriteLine("AddTeamAdmin: " + exception.Message); throw; }
        }
    
        #endregion

        #region Remove
        /// <summary>
        /// Remove a team from the teams table, since teamID is a foreign key to the following tables: isAdmin, isMember
        /// deleting the team from teams table will delete all entries in the tables mentioned above that have the ID of the team 
        /// </summary>
        /// <param name="teamID"></param>
        public static void removeTeam(int teamID)
		{
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM Teams WHERE TeamID = @teamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("Team " + teamID + " is no longer in the teams table");
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("RemoveTeam: " + exception.Message); throw; }
        }
        /// <summary>
        /// Removes a member from the team and update number of members in the team
        /// </summary>
        /// <returns>True if team becomes empty, false otherwise</returns>
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

                query = "SELECT Count(*) FROM isMember WHERE TeamID = @TeamID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@teamID", SqlDbType.Int).Value = teamID;

                dataReader = command.ExecuteReader();
                int MembersNumber = dataReader.Read() ? dataReader.GetInt32(0) : 0;
                command.Parameters.Clear(); dataReader.Close();

                query = "UPDATE Teams SET MembersNumber = @membersNumber WHERE TeamID = @teamID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@membersNumber", SqlDbType.Int).Value = MembersNumber;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;

                dataReader = command.ExecuteReader();
                command.Parameters.Clear(); dataReader.Close();
                Console.WriteLine(" team with ID = " + teamID + " the team now has " + MembersNumber + " members left");
                
                sqlConnection.Close();


                if (MembersNumber == 0) { return true; }

                return false;
            }
            catch (Exception exception) { Console.WriteLine("removeTeamMember: " + exception.Message); throw; }   
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

                Console.WriteLine(username + " is no longer a team Admin");
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return true;
            }
            catch (Exception exception) { Console.WriteLine("removeTeamAdmin: " + exception.Message); throw; }
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
            catch (Exception exception) { Console.WriteLine("getTeamName: " + exception.Message); throw; }
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
            catch (Exception exception) { Console.WriteLine("getUserTeams: " + exception.Message); throw; }
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
                while (dataReader.Read()) { members.Add(dataReader.GetString(0)); }
                
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return members;
            }
            catch (Exception exception) { Console.WriteLine("getTeamMembers: " + exception.Message); throw; }
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
                while (dataReader.Read()) { admins.Add(dataReader.GetString(0)); }
               
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return admins;
            }
            catch (Exception exception) { Console.WriteLine("getTeamAdmins: " + exception.Message); throw; }
        }
        #endregion
    }
}
