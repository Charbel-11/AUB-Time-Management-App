using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface ITeamAccountConnector {

        // Create a team given an admin username, a team name, and a list of members usernames 
        void createTeam(int ConnectionID, string admin, string teamName, List<string> members);

        // Add a member to a given team
        void addMember(int ConnectionID, int teamID, string userToAdd);
    }
}
