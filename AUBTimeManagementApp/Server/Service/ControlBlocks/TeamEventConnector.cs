using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace Server.Service.ControlBlocks
{
    public class TeamEventConnector : ITeamEventConnector
    {
        public void CreateTeamEvent(int teamID, Event _event)
        {

            // Add the event to the schedule of the planner using the connector between the events and the schedules handlers
            IEventScheduleConnector eventScheduleConnector = new EventScheduleConnector();
            eventScheduleConnector.AddPersonalEvent(_event.plannerUsername, _event);

            //Add the team event to the team schedule 
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.AddEventToTeam(teamID, _event.eventID);

            ITeamsHandler teamsHandler = new TeamsHandler();
            // Get the team members using the teams handler
            List<string> members = teamsHandler.GetTeamUsers(teamID);

            // Add invitations to the team members using the Invitation 
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.SendInvitations(members, _event.eventID, teamID, _event.plannerUsername);
        }
    }
}
