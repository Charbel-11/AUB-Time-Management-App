using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    public class InvitationsStorage
    {
        public void AddInvitation(int userId, int eventID, string senderUsername)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isInvitee(EventID, Username, SenderUsername) " +
                                "VALUES (@EventID, @Username, @SenderUsername)";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = userId.ToString();
                command.Parameters.Add("@SenderUsername", SqlDbType.NVarChar).Value = senderUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddInvitation: " + exception.Message); throw; }
        }

        public List<Invitation> GetUserInvitations(string username)
        {
            try
            {
                Console.WriteLine("Getting invitations from events DB");
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT * FROM isInvitee WHERE Username = @Username ";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username.GetHashCode().ToString();

                SqlDataReader dataReader = command.ExecuteReader();

                List<Invitation> invitations = new List<Invitation>();
                while (dataReader.Read())
                {
                    string _username = dataReader.GetString(0);
                    int eventID = dataReader.GetInt32(1);
                    string senderUsername = dataReader.GetString(2);
                    Invitation invitation = new Invitation(new Event(eventID), senderUsername, 0);
                    invitations.Add(invitation);
                    Console.WriteLine("Retrieving invitation to event " + eventID.ToString() + " | Sent by " + senderUsername);
                }
                sqlConnection.Close(); return invitations;
            }
            catch (SqlException exception) { Console.WriteLine("GetUserInvitations: " + exception.Message); throw; }
        }

        public void RemoveInvitation(int userId, int eventId)
        {

        }
    }
}
