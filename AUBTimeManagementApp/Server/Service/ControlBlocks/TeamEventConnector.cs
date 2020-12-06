using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;
using System.Linq;
using System;

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

        /// <summary>
        /// Removes a team member from the team, removes all team evnst invitations sent to him
        /// removes all upcoming team events from his schedule and if the team becomes empty, deletes the team
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="userToRemove"></param>
        /// <param name="removalDate"></param>
        public void RemoveTeamMember(int teamID, string userToRemove, DateTime removalDate)
		{

            //Remove the member from isMemberTable
            ITeamsHandler teamsHandler = new TeamsHandler();
            bool isEmpty = teamsHandler.RemoveMemberRequest(teamID, userToRemove);

            //Remove all upcoming events related to this team from his schedule
            IEventsHandler eventsHandler = new EventsHandler();
            List<int> upcomingTeamEvents = eventsHandler.GetIDsOfUpcomingTeamEvents(teamID, removalDate);

            //if the team becomes empry
            if (isEmpty)
            {
                //remove team from teams table, this removes all members of the team from isMember and all the team admins from isAdmin
                teamsHandler.RemoveTeam(teamID);

                //remove all events in the upcoming events list from the events table, 
                //this removes its invitation and all invitations sent to team members related to this event, and also reamoves it from all the members' schedules 
                //(isUSerAttendee), and also removes the eventa from isTeamAttendee
                IEventsHandler eventsHandler1 = new EventsHandler();
                foreach (int eventID in upcomingTeamEvents)
                {
                    eventsHandler1.CancelEvent(eventID);
                }
            }

			else
			{
                //If user was admin remove him from isAdmin table
                teamsHandler.ChangeAdminState(teamID, userToRemove, false);

                ISchedulesHandler schedulesHandler = new SchedulesHandler();
                foreach (int eventID in upcomingTeamEvents)
                {
                    schedulesHandler.RemoveEventFromUserSchedule(userToRemove, eventID);
                }

                //Remove all invitations related to this team sent to this user
                IInvitationsHandler invitationsHandler = new InvitationsHandler();
                invitationsHandler.RemoveSpecificUserInvitations(teamID, userToRemove);
            }

            //inform all online users that are members of this team
            List<string> teamMembers = teamsHandler.GetTeamMembers(teamID);
            foreach (string member in teamMembers)
            {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(member, out int cID))
                    ServerTCP.PACKET_MemberRemoved(cID, teamID, userToRemove);
            }

            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToRemove, out int ID))
                ServerTCP.PACKET_MemberRemoved(ID, teamID, userToRemove);

        }

    }
}
