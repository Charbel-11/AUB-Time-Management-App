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
        List<int> getFilteredUserEvents(string username, bool low, bool mid, bool high);
        Event CreatePersonalEvent(string eventname, int priority, DateTime startDate, DateTime endDate);
        Event CreateTeamEvent();
        bool UpdatePersonalEvent();
        bool CancelPersonalEvent();
        bool CancelTeamEvent();
        void RemoveEvent(int eventId);
        void RemoveUserFromEventAttendees(int eventId, string username);
        List<Event> GetEventList(List<int> eventsIDs);
    }
}
