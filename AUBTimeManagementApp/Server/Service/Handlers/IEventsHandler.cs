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
        /// <summary>
        /// add an event to the events table and return a list of conflicting events in case of conflict
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newEvent"></param>
        /// <returns>ID of the created Event</returns>
        int CreateEvent(Event _event);

        /// <summary>
        /// Modify an event in the events table
        /// </summary>
        /// <param name="updatedEvent"></param>
        void UpdateEvent(Event updatedEvent);

        /// <summary>
        /// delete an event from the events table
        /// </summary>
        /// <param name="eventId"></param>
        void CancelEvent(int eventID);

        /// <summary>
        /// get the details of the events with ID in the eventsIds list
        /// need to tell wether we are getting events for team schedule or user shcedule to know
        /// where to get the priority from
        /// </summary>
        /// <param name="eventsIDs"></param>
        /// <param name="getTeamEvents"></param>
        /// <param name="username"></param>
        /// <param name="teamID"></param>
        /// <returns></returns>
        List<Event> GetEvents(List<int> eventsIDs, bool getTeamEvents, string username, int teamID);


        /// <summary>
        /// get the IDs of events in the user's schedule filtered according to priority
        /// </summary>
        /// <param name="username"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        List<int> getFilteredUserEvents(string username, bool low, bool mid, bool high);


        /// <summary>
        /// get the IDs of events in the user's schedule filtered according to priority
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="minStartDate"></param>
        /// <returns></returns>
        List<int> GetIDsOfUpcomingTeamEvents(int teamID, DateTime minStartDate);
    }
}
