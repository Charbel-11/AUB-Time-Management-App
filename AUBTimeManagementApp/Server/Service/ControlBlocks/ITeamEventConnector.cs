using Server.DataContracts;
using System;

namespace Server.Service.ControlBlocks
{
    public interface ITeamEventConnector
    {
        /// <summary>
        /// Add event and its priority to the list of events in the team's schedule
        /// get the list of team members
        /// send invitations to the event to all team members
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="_event"></param>
        void CreateTeamEvent(int teamID, Event addedEvent);

        /// <summary>
        /// Removes a team member from the team, removes all team evnst invitations sent to him
        /// removes all upcoming team events from his schedule and if the team becomes empty, deletes the team
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="userToRemove"></param>
        /// <param name="removalDate"></param>>
        void RemoveTeamMember(int teamID, string userToRemove, DateTime removalDate);
    }
}
