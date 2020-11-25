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

        public void RemoveInvitation(int userId, int eventId)
        {

        }

        public List<int> GetInvitations(int userId)
        {
            return null;
        }
    }
}
