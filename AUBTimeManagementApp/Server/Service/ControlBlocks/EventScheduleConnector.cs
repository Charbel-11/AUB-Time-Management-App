using Server.DataContracts;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Service.ControlBlocks
{
    public class EventScheduleConnector : IEventScheduleConnector
    {
		#region user related

        /// <summary>
        /// Add the event to the events table and to add (eventId, username, priority) to isUserAttendee table
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventPriority"></param>
        /// <param name="plannerUsername"></param>
        /// <param name="eventName"></param>
        /// <param name="eventStart"></param>
        /// <param name="eventEnd"></param>
        /// <param name="isTeamEvent"></param>
        /// <returns> return a pair consisting of an event object containing the event details and a list of events that conflict the added event</returns>
		public KeyValuePair<Event, List<Event>> AddUserEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd, bool isTeamEvent)
        {
            // Add event to the events tables
            Event addedEvent = new Event(0, eventPriority, plannerUsername, eventName, eventStart, eventEnd, isTeamEvent);
            IEventsHandler _eventsHandler = new EventsHandler();
            int eventID = _eventsHandler.CreateEvent(addedEvent);
            addedEvent.eventID = eventID;

            //check for conflict with the conflict checker
            IConflictChecker conflictChecker = new ConflictChecker();
            List<Event> conflictingEvents = conflictChecker.ConflictExists(username, addedEvent);

            // Add event id to the user's schedule
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            _schedulesHandler.AddEventToUserSchedule(username, addedEvent.eventID, eventPriority);

            return new KeyValuePair<Event, List<Event>>(addedEvent, conflictingEvents);
        }

        /// <summary>
        /// get the list of events that the user is attending
        /// </summary>
        /// <param name="username"></param>
        /// <returns>list of event objects containing the details of the events teh user is attending</returns>
        public List<Event> GetUserSchedule(string username)
        {
            // Add event id to the user's schedule
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            List<int> eventsIds = _schedulesHandler.GetUserSchedule(username);
            Console.WriteLine("Now we're gonna retrieve" + eventsIds.Count.ToString() + "events");
            
            //Check if List is empty before getting the events details
            List<Event> _events = new List<Event>();
            if(eventsIds.Count()!= 0)
			{
                //Get events from the events tables
                IEventsHandler _eventsHandler = new EventsHandler();
                _events = _eventsHandler.GetEvents(eventsIds, false, username, 0);
                Console.WriteLine("We retrieved" + _events.Count.ToString() + "events");
            }

            return _events;
        }

        /// <summary>
        /// get the details of an event with ID = eventID from events table
        /// gets the priority of the event in the user's schedule from isAttendee table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="username"></param>
        /// <returns>Event object caontaining all the event details</returns>
        public Event GetUserEventInDetail(int eventID, string username)
        {
            IEventsHandler _eventsHandler = new EventsHandler();
            List<int> singleEvent = new List<int>{ eventID };
            return _eventsHandler.GetEvents(singleEvent,false, username, 0).ElementAt(0);
        }

        /// <summary>
        /// if the event the user wants to remove from his schedule is a team event, then the (username,eventID) is removed from isUSerAttendee table
        /// else the event is removed from the events table and isUSerAttendee table
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventID"></param>
        /// <param name="isTeamEvent"></param>
        public void CancelUserEvent(string username, int eventID, bool isTeamEvent)
        {
            // if the event is a personal event, remove the event from events table and isAttendee table
			if (!isTeamEvent)
			{
                IEventsHandler _eventsHandler = new EventsHandler();
                _eventsHandler.CancelEvent(eventID);
            }

            // if the Event is a team event, remove Event from the user's schedule only (isAttendee table)
            else
            {
                ISchedulesHandler _schedulesHandler = new SchedulesHandler();
                _schedulesHandler.RemoveEventFromUserSchedule(username, eventID);
            }
            
        }

        /// <summary>
        /// update the event in events table and update its priority in the user's schedule in isUSerAttendee table
        /// </summary>
        /// <param name="updatedEvent"></param>
        /// <param name="username"></param>
        public void ModifyUserEvent(Event updatedEvent, string username)
        {
            //Check for timr conflict if we decide to do something in case of conflict
            //if not move function to eventsHandler no need for connector.
            Console.WriteLine("server is updating the event with ID = "+updatedEvent.eventID);
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.UpdateEvent(updatedEvent);

            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.updateUserEventPriority(updatedEvent.eventID, username, updatedEvent.priority);
        }

        public List<Event> GetEventsInDetail(string username)
        {
            /* // Extract the list of events id for this user
             ISchedulesHandler _schedulesHandler = new SchedulesHandler();
             List<int> userEvents = _schedulesHandler.GetUserSchedule(username);

             // Exctract events in details
             IEventsHandler _eventsHandler = new EventsHandler();
             List<Event> userEventsInDetail = _eventsHandler.GetEvents(userEvents, false, username,0);

             return userEventsInDetail;*/
            return null;

        }

        #endregion

        #region team related

        /// <summary>
        /// get the list of eventIDS that the team organized
        /// get a list of event objects with details of every event whose ID is in the list
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns>list of event objects containing event details that are organized by the team</returns>
        public List<Event> GetTeamSchedule(int teamID)
		{
            // Add event id to the user's schedule
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            List<int> eventIDs = schedulesHandler.GetTeamSchedule(teamID);
            Console.WriteLine("Now we're gonna retrieve" + eventIDs.Count + "events");

            //Check if List is empty before getting the events details
            List<Event> eventsList = new List<Event>();
            if (eventIDs.Count != 0)
            {
                // Get the events from eventIDs list and add them to the events list
                var eventsHandler = new EventsHandler();
                eventsList = eventsHandler.GetEvents(eventIDs, true, "", teamID);
                Console.WriteLine("We retrieved" + eventsList.Count + "events");
            }

            return eventsList;
        }

        /// <summary>
        /// update the event in events table and update its priority in the team's schedule in isTeamAttendee table
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="updatedEvent"></param>
        public void ModifyTeamEvent(int  teamID, Event updatedEvent)
        {
            //Check for timr conflict if we decide to do something in case of conflict
            //if not move function to eventsHandler no need for connector.
            Console.WriteLine("server is updating the event with ID = " + updatedEvent.eventID);
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.UpdateEvent(updatedEvent);

            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.updateTeamEventPriority(updatedEvent.eventID, teamID, updatedEvent.priority);
        }


        #endregion
    }
}
