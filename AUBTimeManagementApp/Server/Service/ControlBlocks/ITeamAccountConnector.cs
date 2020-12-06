using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface ITeamAccountConnector {
        void createTeam(int ConnectionID, string admin, string teamName, List<string> members);
        void addMember(int ConnectionID, int teamID, string userToAdd);
    }
}
