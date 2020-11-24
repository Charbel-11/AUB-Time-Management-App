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
        /********************user schedule********************/

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


        /********************team schedule********************/

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
        public static bool AddToTeamSchedule(int TeamID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// delete eventID from team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool DelFromTeamSchedule(int TeamID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// Get list of event IDs from team schedule with ID = teamID
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the team </returns>
        public static List<int> GetTeamSchedule(int TeamID)
        {

            return null;
        }

    }
}
