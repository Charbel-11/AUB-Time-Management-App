using Server.DataContracts;
using System;

namespace Server.Service.ControlBlocks
{
    public interface ITeamEventConnector
    {
        void CreateTeamEvent(int teamID, Event addedEvent);
        bool RemoveTeamMember(int teamID, string userToRemove, DateTime removalDate);
    }
}
