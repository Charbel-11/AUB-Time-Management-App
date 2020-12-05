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
        int CreateEvent(Event _event);
        void UpdateEvent(Event updatedEvent);
        void CancelEvent(int eventID);
        void RemoveUserFromEventAttendees(int eventId, string username);
        List<Event> GetEvents(List<int> eventsIDs, bool getTeamEvents, string username, int teamID);
        List<int> getFilteredUserEvents(string username, bool low, bool mid, bool high);
        List<int> GetIDsOfUpcomingTeamEvents(int teamID, DateTime minStartDate);
    }
}
