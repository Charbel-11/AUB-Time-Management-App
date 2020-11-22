using Server.DataContracts;
using Server.Service.Exceptions;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public class EventScheduleConnector : IEventScheduleConnector
    {
        public void AddPersonalEvent(string username, Event _event)
        {
            //check for conflict with the conflict checker
            IConflictChecker conflictChecker = new ConflictChecker();
            List<int> conflictingEvents = conflictChecker.ConflictExists(username, _event);


            // Add event id to the user's schedule
            ISchedulesHandler _schedulesHandler = new SchedulesHandler();
            _schedulesHandler.AddEventToList(username, _event.ID);

            // Add event to the events tables
            IEventsHandler _eventsHandler = new EventsHandler();
            _eventsHandler.CreateEvent(_event);

            if (conflictingEvents.Count != 0)
            {
                throw new ConflictException("Conflict", conflictingEvents);
            }
        }

        public void CancelPersonalEvent(string username, int eventID)
        {

        }

        public void UpdatePersonalEvent(Event updatedEvent)
        {

        }
    }
}
