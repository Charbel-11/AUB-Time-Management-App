using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Server.DataContracts;
using Server.Service.ControlBlocks;
using Server.Service.Exceptions;

namespace Server.Service.Handlers
{
    public class EventsHandler : IEventsHandler   {

        public EventsStorage _eventStorage;
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



        /* Incomplete ! */
        /// <summary>
        /// add an event to the events table and return a list of conflicting events in case of conflict
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        public void CreatePersonalEvent(string username, Event newEvent)
        {
            //check for conflict with the conflict checker
            IConflictChecker conflictChecker = new ConflictChecker();
            List<int> conflictingEvents = conflictChecker.ConflictExists(username, newEvent);
            if (conflictingEvents.Count == 0) /* no conflict -> proceed */
            {
                //add newEvent to events table
                //ask schedule hadler to update user's schedule (event list)
            }
            else
            {
                throw new ConflictException("Conflict", conflictingEvents);
            }


            //return list of conflicting events if adding was successful.....
            

        }

        public Event CreateTeamEvent()
        {
            //
            return null;
        }

        /// <summary>
        /// delete an event from the events table
        /// </summary>
        /// <param name="eventId"></param>
        public void RemoveEvent(int eventId)
        {
            RemoveEventFromUniversalEventsDB(eventId);
        }

  
        public void RemoveUserFromEventAttendees(int eventID, string username)
        {
            /*// get event
            Event _event = GetEvent(eventId);
            List<string> updatedAttendees = new List<string> ();
            for (int i =0; i <_event.attendees.Count; i++)
            {
                if (_event.attendees[i] != username)
                    updatedAttendees.Add(_event.attendees[i]);
            }

            Event updatedEvent = new Event(_event.ID, _event.priority, _event.plannerUsername,
            _event.eventName, _event.startTime, _event.endTime, _event.teamEvent, updatedAttendees);
           
            _eventStorage.UpdateEvent(updatedEvent);*/


            ////////////////////////////////////////////
            //Decrement the number of event attendees in events table
            //Remove the row username,eventID from isAttendee table
        }


        /// <summary>
        /// Modify an event in the events table
        /// </summary>
        /// <returns></returns>
        public bool UpdatePersonalEvent(Event updatedEvent)
		{
            //get event from db
            Event oldEvent = GetEvent(updatedEvent.ID);
            // get event info to be updated (time, name, priority, attendees)
            //check for conflict with the conflict checker only if there is a time update
            //update event info in event storage if no time conflict
            return false;
		}


        /// <summary>
        /// remove the event from the user's schedule
        /// </summary>
        /// <returns></returns>
        public bool CancelPersonalEvent(string username, int eventID)
		{
            //delete the row username, userID from isAttendee table
            //decrement number of attendees of event with ID = eventID in events table
            // if number of attendees is now zero delete event from events table
            return false;
		}
      

        public bool CancelTeamEvent()
		{
            //get ID of group event to be cancelled
            //get list of event attendees
            //ask schedules handler to remove event from events list of each of the attendees
            //delete event from event storage
            return false;
		}

        /// <summary>
        /// return a list the events whose IDs are in the list eventsIDs
        /// </summary>
        /// <param name="eventsIDs"></param>
        /// <returns></returns>
        public List<Event> GetEventList(List<int> eventsIDs)
		{
            if (_eventStorage == null) { return new List<Event>() { }; }
            return _eventStorage.GetAllEvents(eventsIDs);
		}



        /****************************** UTILITY FUNCTIONS ********************************/
        private Event GetEvent(int eventId)
        {
            return _eventStorage.GetEvent(eventId);
        }
        private void AddEventToUniversalEventsDB(Event _event)
        {
            _eventStorage.AddEvent(_event);
        }

        private void RemoveEventFromUniversalEventsDB(int eventId)
        {
            _eventStorage.RemoveEvent(eventId);
        }

        private void UpdateEventInUniversalEventsDB(Event _event)
        {
            _eventStorage.UpdateEvent(_event);
        }
    }
}
