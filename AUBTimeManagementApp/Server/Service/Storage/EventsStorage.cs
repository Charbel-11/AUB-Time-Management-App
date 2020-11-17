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
        
    }
}
