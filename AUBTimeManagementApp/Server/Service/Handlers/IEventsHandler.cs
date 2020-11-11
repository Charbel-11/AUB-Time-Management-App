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
        Event CreatePersonalEvent(string eventname, int priority, DateTime startDate, DateTime endDate);
        Event CreateTeamEvent();
        bool UpdatePersonalEvent();
        bool CancelPersonalEvent();
        bool CancelTeamEvent();
        Event GetPersonalEvent(int eventID);


    }
}
