using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;
using System;

namespace Server.Service.ControlBlocks
{
    public class InvitationConnector : IInvitationsConnector
    {

        public Event AcceptInvitation(string username, int invitationID, int eventID, int teamID) {
   
            List<int> singleEvent = new List<int> { eventID };
            Event acceptedEvent = EventsStorage.GetEvents(singleEvent, " ", teamID, true)[0];

            // Add the event to the user schedule
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.AddEventToUserSchedule(username, eventID, acceptedEvent.priority);

            // Now the event is added we can remove the invitation
            // Note that the order is important because in case adding the event fails we don't want to loose the invitation
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.AcceptInvitation(username, invitationID);

            return acceptedEvent;
        }

        public void DeclineInvitation(string username, int invitationID)
        {
            //Remove invitations
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.DeclineInvitation(username, invitationID);

        }

        public void InviteNewMemberToEvents(string username, int teamID)
        {
            //get all upcoming events related to this team in his schedule
            IEventsHandler eventsHandler = new EventsHandler();
            List<int> upcomingTeamEvents = eventsHandler.GetIDsOfUpcomingTeamEvents(teamID, DateTime.Now);

            //Get invitationsIDs of these events
            //Send all the invitations with ID in the invitationIDs list to the newly added member
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.SendInvitationsToNewMember(upcomingTeamEvents, teamID, username);
        }

    }
}
