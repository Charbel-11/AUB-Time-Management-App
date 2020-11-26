using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public interface IInvitationsConnector
    {
        List<Invitation> GetInvitationsDetails(string username);
    }
}
