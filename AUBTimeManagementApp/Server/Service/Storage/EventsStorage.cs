using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    public class EventsStorage {
        public static List<int> getFilteredUserEvents(string username, int priority) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string nestedQuery = "(SELECT EventID FROM isUserAttendee WHERE Username = @Username)";
                string query = "SELECT EventID FROM Events WHERE Priority = @Priority AND EventID IN " + nestedQuery;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("getUserEvents: " + exception.Message); throw; }
        }

        public static List<int> getFilteredTeamEvents(int teamID, int priority) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string nestedQuery = "(SELECT EventID FROM isTeamAttendee WHERE TeamID = @TeamID)";
                string query = "SELECT EventID FROM Events WHERE Priority = @Priority AND EventID IN " + nestedQuery;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("getFilteredTeamEvents: " + exception.Message); throw; }
        }

        // Get all events with IDs in eventIDs
        public static List<Event> GetEvents(List<int> eventsIDs) {
            if(eventsIDs.Count == 0) { return new List<Event>(); }
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string combinedStringEventIDs = string.Join(",", eventsIDs);
                string query = "SELECT EventID, EventName, StartTime, EndTime, Priority, PlannerUsername FROM Events WHERE EventID IN " 
                                + "(" + combinedStringEventIDs +")";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                List<Event> events = new List<Event>();
                while (dataReader.Read()) {
                    int eventID = dataReader.GetInt32(0);
                    string eventName = dataReader.GetString(1);
                    DateTime start = dataReader.GetDateTime(2);
                    DateTime end = dataReader.GetDateTime(3);
                    int priority = dataReader.GetInt32(4);
                    string plannerID = dataReader.GetString(5);
                    Event currEvent = new Event(eventID, priority, plannerID, eventName, start, end);
                    events.Add(currEvent);
                }

               command.Parameters.Clear(); dataReader.Close();
               sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("GetEvents: " + exception.Message); throw; }
        }

        // Add _event to DB
        public static int AddEvent(Event _event) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query =  "INSERT INTO Events(EventName, StartTime, EndTime, Priority, PlannerUsername) " +
                                "VALUES (@EventName, @StartTime, @EndTime, @Priority, @PlannerUsername)";
                
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@EventName", SqlDbType.NVarChar).Value = _event.eventName;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _event.startTime;
                command.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _event.endTime;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = _event.priority;
                command.Parameters.Add("@PlannerUsername", SqlDbType.NVarChar).Value = _event.plannerUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close();

                query = "SELECT TOP 1 EventID FROM Events ORDER BY EventID DESC";
                command = new SqlCommand(query, sqlConnection);
                dataReader = command.ExecuteReader();

                int eventID = dataReader.Read() ? dataReader.GetInt32(0) : -1;
                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return eventID;
            }
            catch (Exception exception) { Console.WriteLine("AddEvent: " + exception.Message); throw; }
        }


        // Remove event with id eventId
        public static void RemoveEvent(int eventID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM Events Where EventID = @eventID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@eventID", SqlDbType.Int).Value = eventID;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("RemoveEvent: " + exception.Message); throw; }
        }

        // Update the event with id _event->EventId
        public static void UpdateEvent(Event _event)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string update = "EventName = @EventName, StartTime = @StartTime, EndTime = @EndTime, Priority = @Priority, PlannerUsername = @PlannerUsername";
                string query = "UPDATE Events SET " + update + " WHERE EventID = @EventID";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = _event.eventID;
                command.Parameters.Add("@EventName", SqlDbType.NVarChar).Value = _event.eventName;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _event.startTime;
                command.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _event.endTime;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = _event.priority;
                command.Parameters.Add("@PlannerUsername", SqlDbType.NVarChar).Value = _event.plannerUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("UpdateEvent: " + exception.Message); throw; }
        }

    }
}
