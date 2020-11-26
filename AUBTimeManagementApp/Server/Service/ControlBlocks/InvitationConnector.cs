using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public class InvitationConnector : IInvitationsConnector
    {
        public List<Invitation> GetInvitationsDetails(string username)
        {
            InvitationsStorage invitationsStorage = new InvitationsStorage();
            List<Invitation> invitations = invitationsStorage.GetUserInvitations(username);

            // Now we should get the details of the events in invitations using the events handler
            IEventsHandler eventsHandler = new EventsHandler();
            for(int i = 0; i < invitations.Count; i++)
            {
                invitations[i].Event = eventsHandler.GetEvent(invitations[i].Event.ID);
            }

            // Now get the teamID of the team corresponding to each event
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            for (int i = 0; i < invitations.Count; i++)
            {
                invitations[i].TeamID = schedulesHandler.GetEventTeam(invitations[i].Event.ID);
            }

            // Return the list of invitations
            return invitations;
        }

        public void AcceptInvitation(string username, int eventID, int teamID, string senderUsername)
        {
            // Add the event to the user schedule
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.AddEventToList(username, eventID);

            // Now the event is added we can remove the invitation
            // Note that the order is important because in case adding the event fails we don't want to loose the invitation
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.AcceptInvitation(username, eventID, senderUsername);

            // \LATER\ teamID is an argument here in case we want to notify the invitation sender later that this user will attend
        }

        public void DeclineInvitation(string username, int eventID, int teamID, string senderUsername)
        {
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.DeclineInvitation(username, eventID, senderUsername);

            // \LATER\ teamID is an argument here in case we want to notify the invitation sender later that this user will not attend
        }

    }
}
