using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    public class InvitationsStorage {
        
        bool invitationExists(int eventID, int teamID, string senderUsername) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT * FROM Invitations WHERE EventID = @EventID AND TeamID = @TeamID AND SenderUsername = @SenderUsername";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                command.Parameters.Add("@SenderUsername", SqlDbType.NVarChar).Value = senderUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                bool res = dataReader.HasRows;
                command.Parameters.Clear(); sqlConnection.Close();
                return res;
            }
            catch (SqlException exception) { Console.WriteLine("invitationExists: " + exception.Message); throw; }
        }

        public void AddInvitation(int eventID, int teamID, string senderUsername) {
            try {
                if (!invitationExists(eventID, teamID, senderUsername)) { }
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO Invitations (EventID, TeamID, SenderUsername) " +
                                "VALUES (@EventID, @TeamID @SenderUsername)";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                command.Parameters.Add("@SenderUsername", SqlDbType.NVarChar).Value = senderUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddInvitation: " + exception.Message); throw; }
        }

        public void AddUserInvitation(string username, int invitationID) { 
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isInvited (Username, InvitationID) " +
                                "VALUES (@Username, @InvitationID)";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddUserInvitation: " + exception.Message); throw; }
        }

        public List<int> GetUserInvitations(string username)
        {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT InvitationID FROM isInvited WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> invitations = new List<int>();
                while (dataReader.Read()) { invitations.Add(dataReader.GetInt32(0)); }
                sqlConnection.Close(); return invitations;
            }
            catch (SqlException exception) { Console.WriteLine("GetUserInvitations: " + exception.Message); throw; }
        }

        public List<Invitation> GetInvitations(List<int> invitationIDs) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string combinedStringInvitationIDs = string.Join(",", invitationIDs);
                string query = "SELECT * FROM Invitations WHERE InvitationID IN " + "(" + combinedStringInvitationIDs + ")";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                List<Invitation> invitations = new List<Invitation>();
                while (dataReader.Read()) {
                    int invitationID = dataReader.GetInt32(0);
                    int eventID = dataReader.GetInt32(1);
                    int teamID = dataReader.GetInt32(2);
                    string senderUsername = dataReader.GetString(3);

                    Invitation curInvite = new Invitation(invitationID, eventID, teamID, senderUsername);
                    invitations.Add(curInvite);
                }

                command.Parameters.Clear(); return invitations;
            }
            catch (SqlException exception) { Console.WriteLine("GetEvent: " + exception.Message); throw; }
        }

        public void RemoveUserInvitation(string username, int invitationID)
        {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM isInvited WHERE Username = @Username AND InvitationID = @InvitationID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                SqlDataReader dataReader = command.ExecuteReader();
                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("RemoveInvitation: " + exception.Message); throw; }

        }
    }
}
