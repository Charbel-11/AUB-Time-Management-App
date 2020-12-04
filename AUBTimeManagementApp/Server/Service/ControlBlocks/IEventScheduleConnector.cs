using Server.DataContracts;
using System;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        KeyValuePair<Event, List<Event>> AddUserEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd, bool isTeamEvent);
        void CancelUserEvent(string username, int eventID, bool isTeamEvent);
        void UpdateUserEvent(Event updatedEvent, string username);
        Event GetUserEventInDetail(int eventID);
        List<Event> GetEventsInDetail(string username);
        List<Event> GetUserSchedule(string username);
    }
}
