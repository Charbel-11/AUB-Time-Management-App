using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Server.DataContracts;
using Server.Service.ControlBlocks;

namespace Server.Service.Handlers
{
    public class EventsHandler : IEventsHandler   {
        public EventsHandler()
        {
        
        }

        public List<int> getFilteredUserEvents(string username, bool low, bool mid, bool high)
        {
            List<int> events = new List<int>();
            if (low) { events.AddRange(EventsStorage.getFilteredUserEvents(username, 1)); }
            if (mid) { events.AddRange(EventsStorage.getFilteredUserEvents(username, 2)); }
            if (high) { events.AddRange(EventsStorage.getFilteredUserEvents(username, 3)); }
            return events;
        }




        //add an event to the events table and return a list of conflicting events in case of conflict
        public int CreateEvent(Event newEvent)
        {
            return EventsStorage.AddEvent(newEvent);
        }


        /// <summary>
        /// delete an event from the events table
        /// </summary>
        /// <param name="eventId"></param>
        public void CancelEvent(int eventId)
        {
            EventsStorage.RemoveEvent(eventId);
        }

        /// <summary>
        /// Modify an event in the events table
        /// </summary>
        /// <param name="updatedEvent"></param>
        public void UpdateEvent(Event updatedEvent)
		{
            // we eant to check for conflict get start and end time of odl event and
            // return a boolean indicating wether there was a time change

            //update event in events table
            EventsStorage.UpdateEvent(updatedEvent);
		}

        // get the details of the events with Ids in the list
        public List<Event> GetEvents(List<int> eventsIDs, bool getTeamEvents, string username, int teamID)
		{
            return EventsStorage.GetEvents(eventsIDs, username, teamID, getTeamEvents);
		}

        public List<int> GetIDsOfUpcomingTeamEvents(int teamID, DateTime minStartDate)
		{
           return EventsStorage.getIDsOfUpcomingTeamEvents(teamID, minStartDate);
		}
    }
}
