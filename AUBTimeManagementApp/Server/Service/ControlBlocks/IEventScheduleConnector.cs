using Server.DataContracts;
using System;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        KeyValuePair<Event, List<Event>> AddUserEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd);
        void CancelUserEvent(string username, int eventID);
        void UpdateUserEvent(Event updatedEvent);
        Event GetUserEventInDetail(int eventID);
        List<Event> GetEventsInDetail(string username);
        List<Event> GetUserSchedule(string username);
    }
}
