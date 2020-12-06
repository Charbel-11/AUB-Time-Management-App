using Server.DataContracts;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public class ConflictChecker : IConflictChecker
    {
        public ConflictChecker()
        {
            
        }

        // Returns a list of conflicting events with personalEvent
        public List<Event> ConflictExists(string username, Event personalEvent)
        {
            /* Create an instance of the schedules handler since you can only access a user schedule through it */
            ISchedulesHandler scheduleHandler = new SchedulesHandler();
            List<int> eventIDs = scheduleHandler.GetUserSchedule(username);

            if (eventIDs.Count == 0) return null;
            /* Create an instance of the events handler */ 
            IEventsHandler eventsHandler = new EventsHandler();
            
            /* Get details about the events in the user's schedule */
            List<Event> userEvents = eventsHandler.GetEvents(eventIDs, false, username, 0);

            List<Event> conflictingEvents = new List<Event>();

            /* Iterate over the list of events and check for conflict with the new event */

            foreach (Event _event in userEvents)
            {
                /* _event: [] and personalEvent: () */

                /* First case of conflict: [(]) or [()] */
                if (personalEvent.startTime >= _event.startTime && personalEvent.startTime <= _event.endTime)
                    conflictingEvents.Add(_event);

                /* Second case of conflict: ([)] */
                else if (personalEvent.endTime >= _event.startTime && personalEvent.endTime <= _event.endTime)
                    conflictingEvents.Add(_event);

                /* Third case of conflict ([]) */
                else if (personalEvent.endTime >= _event.endTime && personalEvent.startTime <= _event.startTime)
                    conflictingEvents.Add(_event);
            }
            return conflictingEvents;
        }
    }
}
