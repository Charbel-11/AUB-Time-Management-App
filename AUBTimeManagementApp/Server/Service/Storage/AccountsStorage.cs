using Server.Service.Storage;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    class AccountsStorage {

        public static bool usernameExists(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT UserID FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                bool res = dataReader.HasRows;
                sqlConnection.Close(); return res;
            }
            catch (SqlException exception) { Console.WriteLine("usernameExists: " + exception.Message); throw; }
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
                if (dataReader.HasRows) { sqlConnection.Close(); return -1; }
                dataReader.Close();

                string emailQuery = "SELECT UserID FROM Users WHERE Email = @Email";
                command = new SqlCommand(emailQuery, sqlConnection);
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows) { sqlConnection.Close(); return -2; }

                sqlConnection.Close(); return 1;
            }
            catch (SqlException exception) { Console.WriteLine("validateRegistration: " + exception.Message); throw; }
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

                bool res = dataReader.Read() && dataReader.GetString(0) == password;
                sqlConnection.Close(); return res;
            }
            catch (SqlException exception) { Console.WriteLine("validateLogIn: " + exception.Message); return false; }
        }

        public static bool validateChangePassword(string username, string password) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT Password FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                bool res = dataReader.Read() && dataReader.GetString(0) == password;
                sqlConnection.Close(); return res;
            }
            catch (SqlException exception) { Console.WriteLine("validateChangePassword: " + exception.Message); throw; }
        }

        public static bool updatePassword(string username, string password) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                sqlConnection.Close(); return true;
            }
            catch (SqlException exception) { Console.WriteLine("updatePassword: " + exception.Message); throw; }
        }

        public static bool createAccount(string username, string firstName, string lastName, string email, string password, DateTime dateOfBirth) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query =  "INSERT INTO Users(Username, FirstName, LastName, Password, Email, DateOfBirth) " +
                                "VALUES (@Username, @FirstName, @LastName, @Password, @Email, @DateOfBirth)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close(); return true;
            }
            catch (SqlException exception) { Console.WriteLine("createAccount: " + exception.Message); throw; }
        }
    }
}
