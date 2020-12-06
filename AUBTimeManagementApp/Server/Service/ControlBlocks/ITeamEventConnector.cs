using Server.DataContracts;
using System;

namespace Server.Service.ControlBlocks
{
    public interface ITeamEventConnector
    {
        // Create a team event
        // (1) Add the event id to the team's schedule
        // (2) Add the event object to the events table
        void CreateTeamEvent(int teamID, Event addedEvent);

        // Remove a member from a certain team
        void RemoveTeamMember(int teamID, string userToRemove, DateTime removalDate);
    }
}
