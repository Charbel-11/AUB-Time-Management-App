using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        void AddPersonalEvent(string username, Event _event);
        void CancelPersonalEvent(string username, int eventID);
        void UpdatePersonalEvent(Event updatedEvent);
    }
}
