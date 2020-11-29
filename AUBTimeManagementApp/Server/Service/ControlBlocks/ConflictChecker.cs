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

        // Instead of returning a boolean that specifies whether there's a conflict or not
        // This function returns a list of events ids corresponding to the events that overlaps with the new event
        public List<int> ConflictExists(string username, Event personalEvent)
        {
            /* Create an instance of the schedules handler since you can only access a user schedule through it */
            ISchedulesHandler scheduleHandler = new SchedulesHandler();
            
            /* Get user schedule */
            List<int> eventIds = scheduleHandler.GetUserSchedule(username);

            if (eventIds.Count == 0) return null;
            /* Create an instance of the events handler */ 
            IEventsHandler eventsHandler = new EventsHandler();
            
            /* Get details about the events in the user's schedule */
            List<Event> userEvents = eventsHandler.GetEvents(eventIds);

            List<int> conflictingEvents = new List<int>();

            /* Iterate over the list of events and check for conflict with the new event */

            foreach (Event _event in userEvents)
            {
                /* _event: [] and personalEvent: () */

                /* First case of conflict: [(]) */
                if (personalEvent.startTime >= _event.startTime && personalEvent.startTime <= _event.endTime)
                    conflictingEvents.Add(_event.eventID);

                /* Second case of conflict: ([)] */
                else if (personalEvent.endTime >= _event.startTime && personalEvent.endTime <= _event.endTime)
                    conflictingEvents.Add(_event.eventID);
            }
            return conflictingEvents;
        }
    }
}
