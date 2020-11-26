using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface ITeamUsersConnector
    {
        List<string> CreateTeamRequest(string admin, string teamName, List<string> members);
    }
}
