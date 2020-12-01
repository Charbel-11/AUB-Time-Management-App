using Server.DataContracts;
using System;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        Event AddPersonalEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd);
        void CancelPersonalEvent(string username, int eventID);
        void UpdatePersonalEvent(Event updatedEvent);
        Event GetPersonalEventInDetail(int eventID);
        List<Event> GetEventsInDetail(string username);
        List<Event> GetPersonalSchedule(string username);
    }
}
