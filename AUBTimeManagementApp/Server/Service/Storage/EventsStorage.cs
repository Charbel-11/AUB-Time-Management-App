using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    public class EventsStorage {
        public static List<int> getFilteredUserEvents(string username, int priority)
        {
            try
            {
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

                sqlConnection.Close(); return events;
            }
            catch (SqlException exception) { Console.WriteLine("getUserEvents: " + exception.Message); throw; }
        }



        //Check if event exists
        public static bool eventExists(int eventID)
		{
            return true;
		}

        // Get all events with IDs in eventIDs
        public List<Event> GetAllEvents(List<int> eventsIds)
        {
            return null;
        }

        // Exctract an event with eventId from DB
        public Event GetEvent(int eventID)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "Select * From Events Where Name = @eventID";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@eventID", SqlDbType.Int).Value = eventID;
                SqlDataReader dataReader = command.ExecuteReader();
                string eventName = dataReader.GetString(1);
                DateTime start = dataReader.GetDateTime(2);
                DateTime end = dataReader.GetDateTime(3);
                int priority = dataReader.GetInt32(4);
                string plannerUsername = dataReader.GetString(5);
                Event fetchedEvent = new Event(eventID, priority, plannerUsername, eventName, start, end);

                command.Parameters.Clear(); sqlConnection.Close();
            }
            catch (SqlException exception) { Console.WriteLine("GetEvent: " + exception.Message); throw; }
            return null;
        }

        // Add _event to DB
        public void AddEvent(Event _event)
        {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query =  "INSERT INTO Events(EventID, EventName, StartTime, EndTime, Priority, PlannerUsername) " +
                                "VALUES (@EventID, @EventName, @StartTime, @EndTime, @Priority, @PlannerUsername)";
                
                SqlCommand command = new SqlCommand(query, sqlConnection);

                int _eventID = _event.eventName.GetHashCode();
                command.Parameters.Add("@EventID", SqlDbType.Int).Value = _eventID;//_event.ID;
                command.Parameters.Add("@EventName", SqlDbType.NVarChar).Value = _event.eventName;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _event.startTime;
                command.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _event.endTime;
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = _event.priority;
                command.Parameters.Add("@PlannerUsername", SqlDbType.NVarChar).Value = _event.plannerUsername;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); sqlConnection.Close(); 
            }
            catch (SqlException exception) { Console.WriteLine("AddEvent: " + exception.Message); throw; }
        }

        // Remove event with id eventId
        public void RemoveEvent(int eventId)
        {

        }

        // Update the event with id _event->EventId
        public void UpdateEvent(Event _event)
        {

        }
        
    }
}
