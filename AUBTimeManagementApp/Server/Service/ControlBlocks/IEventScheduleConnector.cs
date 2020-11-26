using Server.DataContracts;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        void AddPersonalEvent(string username, Event _event);
        void CancelPersonalEvent(string username, int eventID);
        void UpdatePersonalEvent(Event updatedEvent);
        Event GetPersonalEventInDetail(int eventID);
        List<Event> GetEventsInDetail(string username);
        List<Event> GetPersonalSchedule(string username);
    }
}
