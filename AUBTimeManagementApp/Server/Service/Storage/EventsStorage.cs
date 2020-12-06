using Server.DataContracts;
using Server.Service.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUBTimeManagementApp.Service.Storage
{
    public class EventsStorage {

        /// <summary>
        /// select form isUSerAttendee the events with required priority
        /// </summary>
        /// <param name="username"></param>
        /// <param name="priority"></param>
        /// <returns>returns list of user Events with the required priority</returns>
        public static List<int> getFilteredUserEvents(string username, int priority) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "(SELECT EventID FROM isUserAttendee WHERE Username = @Username AND Priority = @Priority)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                command.Parameters.Clear(); dataReader.Close();
                sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("getFilteredUserSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// select form isTeamAttendee the events with required priority
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="priority"></param>
        /// <returns>returns list of team Events with the required priority</returns>
        public static List<int> getFilteredTeamEvents(int teamID, int priority) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "(SELECT EventID FROM isTeamAttendee WHERE TeamID = @TeamID AND Priority = @Priority)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> events = new List<int>();
                while (dataReader.Read()) { events.Add(dataReader.GetInt32(0)); }

                sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("getFilteredTeamSchedule: " + exception.Message); throw; }
        }

        /// <summary>
        /// Get all events with IDs in eventIDs from events table
        /// get their priority in the user's schedule from isAttendee table
        /// </summary>
        /// <param name="eventsIDs"></param>
        /// <param name="username"></param>
        /// <param name="teamID"></param>
        /// <param name="getTeamEvents"></param>
        /// <returns></returns>
        public static List<Event> GetEvents(List<int> eventsIDs, string username, int teamID, bool getTeamEvents) {
            if(eventsIDs.Count == 0) { return new List<Event>(); }
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string combinedStringEventIDs = string.Join(",", eventsIDs);
                string query = "SELECT EventID, EventName, StartTime, EndTime, PlannerUsername, isTeamEvent, Link FROM Events WHERE EventID IN " 
                                + "(" + combinedStringEventIDs +")";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                List<Event> events = new List<Event>();
                while (dataReader.Read())
                {
                    int eventID = dataReader.GetInt32(0);
                    string eventName = dataReader.GetString(1);
                    DateTime start = dataReader.GetDateTime(2);
                    DateTime end = dataReader.GetDateTime(3);
                    string plannerID = dataReader.GetString(4);
                    bool isTeamEvent = dataReader.GetBoolean(5);
                    string Link = dataReader.GetString(6);
                    Event currEvent = new Event(eventID, 0, plannerID, eventName, start, end, isTeamEvent, Link);
                    events.Add(currEvent);
                }

                dataReader.Close();
                // if getting a user's schedule get the events priorities form isUserAttendee
                if (!getTeamEvents)
                {
                    query = "Select Priority From isUserAttendee WHERE Username = @username AND EventID IN " + "(" + combinedStringEventIDs + ")";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                }

                // if getting a team schedule, get the events priorities from the isTeamAttendee
				else if (getTeamEvents && teamID != 0)
				{
                    query = "Select Priority From isTeamAttendee WHERE EventID IN " + "(" + combinedStringEventIDs + ") AND TeamID = @teamID";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.Add("@teamID", SqlDbType.Int).Value = teamID;
                }

                dataReader = command.ExecuteReader();

                int i = 0;
                int n = events.Count;
                while (dataReader.Read() && i<n )
                {
                    int priority = dataReader.GetInt32(0);
                    events[i].priority = priority;
                    i++;
                }

                command.Parameters.Clear(); dataReader.Close();
               sqlConnection.Close(); return events;
            }
            catch (Exception exception) { Console.WriteLine("GetEvents: " + exception.Message); throw; }
        }

        /// <summary>
        /// add the event to the events table
        /// </summary>
        /// <param name="_event"></param>
        /// <returns>the ID of the event</returns>
        public static int AddEvent(Event _event) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query =  "INSERT INTO Events(EventName, StartTime, EndTime, PlannerUsername, isTeamEvent, Link) " +
                                "VALUES (@EventName, @StartTime, @EndTime, @PlannerUsername, @isTeamEvent, @Link)";
                
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@EventName", SqlDbType.NVarChar).Value = _event.eventName;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _event.startTime;
                command.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _event.endTime;
                command.Parameters.Add("@PlannerUsername", SqlDbType.NVarChar).Value = _event.plannerUsername;
                command.Parameters.Add("@isTeamEvent", SqlDbType.Bit).Value = _event.teamEvent;
                command.Parameters.Add("@Link", SqlDbType.NVarChar).Value = _event.Link;
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


        /// <summary>
        /// Remove event with id eventId form events table
        /// </summary>
        /// <param name="eventID"></param>
        public static void RemoveEvent(int eventID) {
            try {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string query = "DELETE FROM Events Where EventID = @eventID";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@eventID", SqlDbType.Int).Value = eventID;
                SqlDataReader dataReader = command.ExecuteReader();
                Console.WriteLine("Removed event with eventID = " + eventID + "from events table");

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("RemoveEvent: " + exception.Message); throw; }
        }

        /// <summary>
        /// Update the event with id _event->EventId
        /// </summary>
        /// <param name="_event"></param>
        public static void UpdateEvent(Event _event)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string update = "EventName = @EventName, StartTime = @StartTime, EndTime = @EndTime, PlannerUsername = @PlannerUsername, Link = @Link";
                string query = "UPDATE Events SET " + update + " WHERE EventID = @EventID";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.Add("@EventID", SqlDbType.Int).Value = _event.eventID;
                command.Parameters.Add("@EventName", SqlDbType.NVarChar).Value = _event.eventName;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _event.startTime;
                command.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _event.endTime;
                command.Parameters.Add("@PlannerUsername", SqlDbType.NVarChar).Value = _event.plannerUsername;
                command.Parameters.Add("@Link", SqlDbType.NVarChar).Value = _event.Link;
                SqlDataReader dataReader = command.ExecuteReader();

                command.Parameters.Clear(); dataReader.Close(); sqlConnection.Close();
            }
            catch (Exception exception) { Console.WriteLine("UpdateEvent: " + exception.Message); throw; }
        }

        /// <summary>
        /// Get all upcoming events related to team with ID = teamID
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="minStartDate"></param>
        /// <returns></returns>
        public static List<int> getIDsOfUpcomingTeamEvents(int teamID, DateTime minStartDate)
        {
            try
            {
                string connectionString = ConnectionUtil.connectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string nestedQuery = "(SELECT EventID FROM isTeamAttendee WHERE TeamID = @TeamID )";
                string query = "Select EventID FROM Events WHERE StartTime > @minStartDate AND EventID IN " + nestedQuery;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@minStartDate", SqlDbType.DateTime).Value = minStartDate;
                command.Parameters.Add("@TeamID", SqlDbType.Int).Value = teamID;
                SqlDataReader dataReader = command.ExecuteReader();

                List<int> eventIDs = new List<int>();
                while (dataReader.Read()) { eventIDs.Add(dataReader.GetInt32(0)); }
                Console.WriteLine("got ID of " + eventIDs.Count + " upcoming team events");
                sqlConnection.Close(); return eventIDs;
            }
            catch (Exception exception) { Console.WriteLine("GetIDsOfUpcomingTeamEvents: " + exception.Message); throw; }
        }

    }
}
