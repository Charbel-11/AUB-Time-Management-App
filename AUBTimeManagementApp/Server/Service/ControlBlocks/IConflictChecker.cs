using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    interface IConflictChecker
    {
        // Returns a list of conflicting events with personalEvent
        List<Event> ConflictExists(string username, Event personalEvent);

    }
}
