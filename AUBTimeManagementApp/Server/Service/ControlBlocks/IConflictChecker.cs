using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    interface IConflictChecker
    {
        /// <summary>
        /// Get the list of event conflicting with personalEvent
        /// </summary>
        /// <param name="username"></param>
        /// <param name="personalEvent">Event to check conflict with</param>
        /// <returns>List of events ids corresponding to the events that overlaps with the new event</returns>
        List<Event> ConflictExists(string username, Event personalEvent);

    }
}
