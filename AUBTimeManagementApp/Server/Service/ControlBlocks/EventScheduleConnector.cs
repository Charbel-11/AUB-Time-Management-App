using Server.DataContracts;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Service.ControlBlocks
{
    public class EventScheduleConnector : IEventScheduleConnector
    {
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
                _events = _eventsHandler.GetEvents(eventsIds);
                Console.WriteLine("We retrieved" + _events.Count.ToString() + "events");
            }

            return _events;
        }
        public Event GetUserEventInDetail(int eventID)
        {
            IEventsHandler _eventsHandler = new EventsHandler();
            List<int> singleEvent = new List<int>{ eventID };
            return _eventsHandler.GetEvents(singleEvent).ElementAt(0);
        }

        public void CancelUserEvent(string username, int eventID, bool isTeamEvent)
        {
            // Remove Event from the user's schedule
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            _schedulesHandler.RemoveEventFromUserSchedule(username, eventID);

            // if the event is a personal event, remove the event from events table
			if (!isTeamEvent)
			{
                IEventsHandler _eventsHandler = new EventsHandler();
                _eventsHandler.CancelEvent(eventID);
            }
            
        }

        public void UpdateUserEvent(Event updatedEvent, string username)
        {
            //Check for timr conflict if we decide to do something in case of conflict
            //if not move function to eventsHandler no need for connector.
            Console.WriteLine("server is updating the event with ID = "+updatedEvent.eventID);
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.UpdateEvent(updatedEvent);

            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.updatePriority(updatedEvent.eventID, username, updatedEvent.priority);
        }

        public List<Event> GetEventsInDetail(string username)
        {
            // Extract the list of events id for this user
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            List<int> userEvents = _schedulesHandler.GetUserSchedule(username);

            // Exctract events in details
            IEventsHandler _eventsHandler = new EventsHandler();
            List<Event> userEventsInDetail = _eventsHandler.GetEvents(userEvents);

            return userEventsInDetail;

        }
    }
}
