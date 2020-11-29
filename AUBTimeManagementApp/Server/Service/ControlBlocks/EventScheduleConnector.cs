using Server.DataContracts;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Service.ControlBlocks
{
    public class EventScheduleConnector : IEventScheduleConnector
    {
        public void AddPersonalEvent(string username, Event _event)
        {
            //Commented throw exception cause we need to always return the id of the added event to the client.
            // maybe we don't need to check for conflict if we're not gonna anything with the list of conflicting events

            //check for conflict with the conflict checker
            IConflictChecker conflictChecker = new ConflictChecker();
            List<int> conflictingEvents = conflictChecker.ConflictExists(username, _event);

            // Add event id to the user's schedule
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            _schedulesHandler.AddEventToList(username, _event.eventID);

            // Add event to the events tables
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.CreateEvent(_event);

           /* if (conflictingEvents.Count != 0)
            {
                throw new ConflictException("Conflict", conflictingEvents);
            }*/
            Console.WriteLine("Event was added"); 
        }

        public List<Event> GetPersonalSchedule(string username)
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
        public Event GetPersonalEventInDetail(int eventID)
        {
            IEventsHandler _eventsHandler = new EventsHandler();
            List<int> singleEvent = new List<int>{ eventID };
            return _eventsHandler.GetEvents(singleEvent).ElementAt(0);
        }
        public void CancelPersonalEvent(string username, int eventID)
        {
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            _schedulesHandler.RemoveEventFromList(username, eventID);

            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.CancelEvent(eventID);
        }

        public void UpdatePersonalEvent(Event updatedEvent)
        {
            //Check for timr conflict if we decide to do something in case of conflict
            //if not move function to eventsHandler no need for connector.
            Console.WriteLine("server is updating the event with ID = "+updatedEvent.eventID);
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.UpdateEvent(updatedEvent);
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
