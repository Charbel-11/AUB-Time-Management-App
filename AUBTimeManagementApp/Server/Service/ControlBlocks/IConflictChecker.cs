using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    interface IConflictChecker
    {
        List<Event> ConflictExists(string username, Event personalEvent);
    }
}
