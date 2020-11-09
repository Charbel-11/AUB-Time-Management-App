using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class AccountsStorage {

        public static bool usernameExists(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT UserID FROM Users WHERE Username = " + username;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows) { return true; }
                sqlConnection.Close();
            }
            catch (SqlException exception) { throw; }
            return false;
        }

        public static bool isOnline(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT Online FROM Users WHERE Username = " + username;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                return (bool) dataReader.GetValue(0);
                sqlConnection.Close();
            }
            catch (SqlException exception) { throw; }
            return false;
        }

        public static int validateRegistration(string username, string email) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string usernameQuery = "SELECT UserID FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(usernameQuery, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows) { return -1; }
                dataReader.Close();

                string emailQuery = "SELECT UserID FROM Users WHERE Email = @Email";
                command = new SqlCommand(emailQuery, sqlConnection);
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows) { return -2; }

                sqlConnection.Close();
            }
            catch (SqlException exception) { throw; }
            return 1;
        }

        public static bool validateLogIn(string username, string password) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT Password FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read() && dataReader.GetString(0) == password) { return true; }
                sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine(exception.Message); return false; }
            return false;
        }

        public static bool validateChangePassword(string username, string password) {
            return true;
        }

        public static bool updatePassword(string username, string password) {
            return true;
        }

        public static bool createAccount(string username, string firstName, string lastName, string email, string password, DateTime dateOfBirth) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query =  "INSERT INTO Users(Username, FirstName, LastName, Password, Email, DateOfBirth, Online) " +
                                "VALUES (@Username, @FirstName, @LastName, @Password, @Email, @DateOfBirth, @Online)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.Add("@Online", SqlDbType.Bit).Value = false;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear();
                sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine(exception.Message); return false; }
            return true;
        }

        public static int[] getUserTeams(string username) {
            int[] teams = new int[0]; 
            return teams;
        }

    }
}
