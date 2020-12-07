using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    public class InvitationsStorage {
        
        /// <summary>
        /// check if an invitation for the given event exists in the invitations table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="teamID"></param>
        /// <param name="senderUsername"></param>
        /// <returns></returns>
        public static bool invitationExists(int eventID, int teamID, string senderUsername) {
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
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return res;
            }
            catch (Exception exception) { Console.WriteLine("invitationExists: " + exception.Message); throw; }
        }

        /// <summary>
        /// get the ID of an invitation in the Invitations table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="teamID"></param>
        /// <param name="senderUsername"></param>
        /// <returns></returns>
        public static int getInvitationID(int eventID, int teamID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT InvitationID FROM Invitations WHERE EventID = @EventID AND TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                int res = (dataReader.Read() ? dataReader.GetInt32(0) : -1);
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return res;
            }
            catch (Exception exception) { Console.WriteLine("getInvitationID: " + exception.Message); throw; }
        }

        /// <summary>
        /// add invitation to the invitations table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="teamID"></param>
        /// <param name="senderUsername"></param>
        /// <returns></returns>
        public static int AddInvitation(int eventID, int teamID, string senderUsername) {
            try {
                if (invitationExists(eventID, teamID, senderUsername)) { return getInvitationID(eventID, teamID); }
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO Invitations (EventID, TeamID, SenderUsername, Pending) " +
                                "VALUES (@EventID, @TeamID, @SenderUsername, @numberOfInvitees)";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                command.Parameters.Add("@SenderUsername", SqlDbType.NVarChar).Value = senderUsername;
                command.Parameters.Add("@numberOfInvitees", SqlDbType.Int).Value = 0;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return getInvitationID(eventID, teamID);
            }
            catch (Exception exception) { Console.WriteLine("AddInvitation: " + exception.Message); throw; }
        }
        /// <summary>
        /// add invitation to the list of invitations sent to a user and increment the number of pending responses
        /// </summary>
        /// <param name="username"></param>
        /// <param name="invitationID"></param>
        public static void AddUserInvitation(string username, int invitationID) { 
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

                command.Parameters.Clear(); dataReader.Close();

                query = "SELECT Pending FROM Invitations WHERE InvitationID = @InvitationID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                dataReader = command.ExecuteReader();
                int pending = dataReader.Read() ? dataReader.GetInt32(0) : 0;
                command.Parameters.Clear(); dataReader.Close();

                query = "UPDATE Invitations SET Pending = @Pending WHERE InvitationID = @InvitationID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Pending", SqlDbType.Int).Value = pending + 1;
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                dataReader = command.ExecuteReader();
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("AddUserInvitation: " + exception.Message); throw; }
        }
        /// <summary>
        /// get the IDs of the invitations sent to a specific user
        /// </summary>
        /// <param name="username"></param>
        /// <returns>list of invitationsIDs</returns>
        public static List<int> GetUserInvitations(string username)
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
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return invitations;
            }
            catch (Exception exception) { Console.WriteLine("GetUserInvitations: " + exception.Message); throw; }
        }

        /// <summary>
        /// get the details of the invitations with ID in the list
        /// </summary>
        /// <param name="invitationIDs"></param>
        /// <returns>list of Invitation objects containing the details of the invitations</returns>
        public static List<Invitation> GetInvitations(List<int> invitationIDs) {

            if (invitationIDs.Count == 0) { return new List<Invitation>(); }
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string combinedStringInvitationIDs = string.Join(",", invitationIDs);
                string query = "SELECT * FROM Invitations WHERE InvitationID IN " + "(" + combinedStringInvitationIDs + ")";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();
                //store invitations
                List<Invitation> invitations = new List<Invitation>();
                //store teamIDs of the teams that issued the invitations
                List<int> teamIDs = new List<int>();
                while (dataReader.Read()) {
                    int invitationID = dataReader.GetInt32(0);
                    int eventID = dataReader.GetInt32(1);
                    int teamID = dataReader.GetInt32(2);
                    string senderUsername = dataReader.GetString(3);

                    Invitation curInvite = new Invitation(invitationID, eventID, teamID, senderUsername);
                    invitations.Add(curInvite);
                    teamIDs.Add(teamID);					
                }

                Dictionary<int, string> teamNames = new Dictionary<int, string>();
                foreach (int teamID in teamIDs) {
                    command.Parameters.Clear(); dataReader.Close();
                    query = "SELECT TeamName FROM Teams WHERE TeamID = @TeamID";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read()) {                      
                        string teamName = dataReader.GetString(0);
                        teamNames.Add(teamID, teamName);
                    }
                }

                foreach(Invitation invitation in invitations)
				{
                    invitation.teamName = teamNames[invitation.teamID];
				}

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return invitations;
            }
            catch (Exception exception) { Console.WriteLine("GetInvitations: " + exception.Message); throw; }
        }

        /// <summary>
        /// dleete invitation with invitation Id from invitations table
        /// </summary>
        /// <param name="invitationID"></param>
        public static void RemoveInvitation(int invitationID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM Invitations WHERE InvitationID = @InvitationID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                SqlDataReader dataReader = command.ExecuteReader();
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("RemoveInvitation: " + exception.Message); throw; }
        }

        /// <summary>
        /// remove invitation from sent to the user from isInvited 
        /// and update the count of pending responses once it reaches zero
        /// call RemoveInvitation from Invitations table, there is no use for it anymore
        /// </summary>
        /// <param name="username"></param>
        /// <param name="invitationID"></param>
        public static void RemoveUserInvitation(string username, int invitationID)
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
                command.Parameters.Clear(); dataReader.Close();

                query = "SELECT Pending FROM Invitations WHERE InvitationID = @InvitationID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                dataReader = command.ExecuteReader();
                int pending = dataReader.Read() ? dataReader.GetInt32(0) : 1;
                command.Parameters.Clear(); dataReader.Close();

                query = "UPDATE Invitations SET Pending = @Pending WHERE InvitationID = @InvitationID";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Pending", SqlDbType.Int).Value = pending - 1;
                command.Parameters.Add("@InvitationID", SqlDbType.Int).Value = invitationID;

                Console.WriteLine("Removed invitation with ID = " + invitationID + "from the user's invitations");

                dataReader = command.ExecuteReader();
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close(); 
                if(pending == 1) { RemoveInvitation(invitationID); }
            }
            catch (Exception exception) { Console.WriteLine("RemoveInvitation: " + exception.Message); throw; }

        }

        /// <summary>
        /// Get ID of invitations with specific teamID
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        public static List<int> getTeamInvitationIDs(int teamID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT InvitationID FROM Invitations WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> invitationIDs = new List<int>();

                while (dataReader.Read()) { invitationIDs.Add(dataReader.GetInt32(0)); }

                Console.WriteLine("got ID of " + invitationIDs.Count + "invitations to events of team with ID = " + teamID);
                
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return invitationIDs;
            }
            catch (Exception exception) { Console.WriteLine("getTeamInvitationIDs: " + exception.Message); throw; }
        }
    }
}
