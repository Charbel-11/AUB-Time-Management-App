using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public interface ITeamUsersConnector
    {
        List<string> CreateTeamRequest(string admin, string teamName, List<string> members);
    }
}
