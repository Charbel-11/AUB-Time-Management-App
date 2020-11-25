using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public interface ITeamEventConnector
    {
        void CreateTeamEvent(int teamID, Event addedEvent);
    }
}
