using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    public interface IEventsHandler
    {
        void CreateEvent(Event _event);
        void UpdateEvent(Event updatedEvent);
        void CancelEvent(int eventID);
        void RemoveUserFromEventAttendees(int eventId, string username);
        List<Event> GetEventList(List<int> eventsIDs);
        List<int> getFilteredUserEvents(string username, bool low, bool mid, bool high);
    }
}
