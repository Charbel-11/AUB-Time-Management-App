using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    public class SchedulesStorage
    {
		#region personal Schedule

		/// <summary>
		/// check if user is atteding any event in isAttendee
		/// </summary>
		/// <returns> return true if found, return false otherwise</returns>
		public bool PersonalScheduleExists(string UserID)
        {
            return true;
        }

        /// <summary>
        /// add eventID to user schedule with id = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public void AddToPersonalSchedule(string username, int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isUserAttendee(EventID, Username) " +
                                "VALUES (@EventID, @Username)";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddToPersonalSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// delete eventID from user schedule with ID = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public void DelFromPersonalSchedule(string username, int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "Delete From isUserAttendee WHERE EventID = @EventID AND Username = @Username";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("Removed event with eventID = " + eventID + " from user schedule");
                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("DeleteFromPersonalSchedule: " + exception.Message); throw; }
        }


        /// <summary>
        /// Get list of event IDs from isAttendee with userID = username
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the user </returns>
        public List<int> GetPersonalSchedule(string username)
		{
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "(SELECT EventID FROM isUserAttendee WHERE Username = @Username)";
  
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                sqlConnection.Close();
                Console.WriteLine("Extracted events = " + events.Count.ToString());
                return events;
            }
            catch (SqlException exception) { Console.WriteLine("GetPersonalSchedule: " + exception.Message); throw; }

        }

		#endregion

		#region Team Schedule

		/// <summary>
		/// check if team schedule with ID = teamID exists
		/// </summary>
		/// <returns> return true if found, return false otherwise</returns>
		public static bool TeamScheduleExists(int TeamID)
        {
            return true;
        }

        /// <summary>
        /// add eventID to team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public void AddToTeamSchedule(int teamID, int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "INSERT INTO isTeamAttendee(EventID, TeamID) " +
                                "VALUES (@EventID, @TeamID)";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.NVarChar).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();
                Console.WriteLine("Event added to team schedule");

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("AddToTeamSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// delete eventID from team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public void DelFromTeamSchedule(int teamID, int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "Delete From isTeamAttendee WHERE EventID = @EventID AND TeamID = @TeamID";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                command.Parameters.Add("@TeamID", SqlDbType.NVarChar).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine("Removed event with eventID = " + eventID + " from team schedule");
                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("DeleteFromTeamSchedule: " + exception.Message); throw; }
        }

        // Get the teamID for a team event with id = eventID
        public int GetEventTeam(int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "(SELECT TeamID FROM isTeamAttendee WHERE EventID = @EventID)";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = eventID;
                SqlDataReader dataReader = command.ExecuteReader();

                int teamID = 0;
                while (dataReader.Read()) { teamID = dataReader.GetInt32(0); }

                sqlConnection.Close();
                Console.WriteLine("Event " + eventID.ToString() + " corresponds to team " + teamID.ToString());
                return teamID;
            }
            catch (SqlException exception) { Console.WriteLine("GetEventTeam: " + exception.Message); throw; }
        }

        /// <summary>
        /// Get list of event IDs from team schedule with ID = teamID
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the team </returns>
        public List<int> GetTeamSchedule(int teamID)
        {

            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "(SELECT EventID FROM isTeamAttendee WHERE TeamID = @TeamID)";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@TeamID", SqlDbType.NVarChar).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> eventIDs = new List<int>();
                while (dataReader.Read()) { eventIDs.Add(dataReader.GetInt32(0)); }

                sqlConnection.Close();
                Console.WriteLine("Extracted events = " + eventIDs.Count.ToString());
                return eventIDs;
            }
            catch (SqlException exception) { Console.WriteLine("GetTeamSchedule: " + exception.Message); throw; }
        }
		#endregion
	}
}
