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
          
            //Add the team event to the team schedule 
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.AddEventToTeamSchedule(teamID, _event.eventID, _event.priority);

            // Get the team members using the teams handler
            ITeamsHandler teamsHandler = new TeamsHandler();
            List<string> members = teamsHandler.GetTeamMembers(teamID);

           // Add invitations to the team members using the Invitation 
           IInvitationsHandler invitationsHandler = new InvitationsHandler();
           invitationsHandler.SendInvitations(members, _event.eventID, teamID, _event.plannerUsername);
        }


    }
}
