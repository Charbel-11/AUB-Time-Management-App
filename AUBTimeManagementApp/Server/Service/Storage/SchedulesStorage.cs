using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    public class SchedulesStorage
    {
        #region personal Schedule
        /// <summary>
        /// add eventID to user schedule with id = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static void AddToUserSchedule(string username, int eventID, int priority) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isUserAttendee(Username, EventID, Priority) " +
                                "VALUES (@Username, @EventID, @Priority)";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("AddToPersonalSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// delete eventID from user schedule with ID = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static void DeleteFromUserSchedule(string username, int eventID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM isUserAttendee WHERE EventID = @EventID AND Username = @Username";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("Removed event with eventID = " + eventID + " from user schedule");
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("DeleteFromPersonalSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// Get list of event IDs from isAttendee with userID = username
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the user </returns>
        public static List<int> GetUserSchedule(string username) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT EventID FROM isUserAttendee WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("GetPersonalSchedule: " + exception.Message); throw; }

        }

        public static void UpdateEventPrioriy(int eventID, string username, int priority)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string update = " Priority = @Priority";
                string query = "UPDATE isUserAttendee SET " + update + " WHERE EventID = @EventID AND Username = @Username";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("event priority updated");
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("UpdateEventPriority: " + exception.Message); throw; }
        }

    
    #endregion

        #region Team Schedule

        /// <summary>
        /// add eventID to team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static void AddToTeamSchedule(int teamID, int eventID, int priority) 
        {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isTeamAttendee(EventID, TeamID, Priority) " +
                                "VALUES (@EventID, @TeamID, @Priority)";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("AddToTeamSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// delete eventID from team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static void DeleteFromTeamSchedule(int teamID, int eventID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM isTeamAttendee WHERE EventID = @EventID AND TeamID = @TeamID";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.NVarChar).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("Removed event with eventID = " + eventID + " from team schedule");
                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("DeleteFromTeamSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// Get list of event IDs from team schedule with ID = teamID
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the team </returns>
        public static List<int> GetTeamSchedule(int teamID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "SELECT EventID FROM isTeamAttendee WHERE TeamID = @TeamID";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.NVarChar).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> eventIDs = new List<int>();
                while (dataReader.Read()) { eventIDs.Add(dataReader.GetInt32(0)); }

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return eventIDs;
            }
            catch (Exception exception) { Console.WriteLine("GetTeamSchedule: " + exception.Message); throw; }
        }
		#endregion
	}
}
