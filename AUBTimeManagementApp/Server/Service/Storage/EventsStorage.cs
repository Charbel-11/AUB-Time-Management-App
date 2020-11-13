using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    public class EventsStorage
    {
        //Check if event exists
        public static bool eventExists(int eventID)
		{
            return true;
		}
       /* //Get event name
        public static string getEventName(int eventID)
        {
            string s = "event___1";
            return s;
        }
        //Get event startDate
        public static DateTime getEventStartDate(int eventID)
        {
            DateTime start;
            if (eventID==1){ start = DateTime.Now;}
            else if (eventID == 2) { start = new DateTime(2020, 11, 4, 8, 30, 52);}
            else { start = new DateTime(2020, 11, 12, 8, 30, 52);}
            return start;
        }
        //Get event endDate
        public static DateTime getEventEndDate(int eventID)
        {
            DateTime end;
            if (eventID == 1) { end = DateTime.Now; }
            else if (eventID == 2) { end = new DateTime(2020, 11, 4, 12, 30,52); }
            else { end = new DateTime(2020, 11, 12, 12, 30, 52); }
            return end;
        }
        //Get event priority
        public static int getEventPriority(int eventID)
        {
            int priority = 1;
            return priority;
        }

        //Get event planner
        public static string getEventPlanner(int eventID)
        {
            string planner = "abc";
            return planner;
        }

        //return true if team event, false otherwise
        public static bool isTeamevent(int eventID)
        {
            return false;
        }*/

        // Get all events for a given user
        // Warning: The accounts database should not contain details about events (just the events ids maybe in some concatenated string (?))
        // We need another DB that maps users to a list of eventsIds
        public List<Event> GetAllEvents(List<int> eventsIds)
        {
            return null;
        }

        // Exctract an event with eventId from DB
        public Event GetEvent(int eventId)
        {
            return null;
        }
        // Add _event to DB
        public void AddEvent(Event _event)
        {

        }

        // Remove event with id eventId
        public void RemoveEvent(int eventId)
        {

        }

        // Update the event with id _event->EventId
        public void UpdateEvent(Event _event)
        {

        }

        public List<Event> filterEvents(int priority, List<int> eventIDs)
		{
            return null;
		}
        
    }
}
