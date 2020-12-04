using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public class InvitationConnector : IInvitationsConnector
    {

        public void AcceptInvitation(string username, int invitationID) {

            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            List<int> singleInvitation = new List<int> { invitationID };
            Invitation _Invitation = invitationsHandler.getInvitations(singleInvitation)[0];
            int eventID = _Invitation.eventID;
            List<int> singleEvent = new List<int> { eventID };
            int priority = EventsStorage.GetEvents(singleEvent, " ", _Invitation.teamID, true)[0].priority;

            // Add the event to the user schedule
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            schedulesHandler.AddEventToUserSchedule(username, eventID, priority);

            // Now the event is added we can remove the invitation
            // Note that the order is important because in case adding the event fails we don't want to loose the invitation
            invitationsHandler.AcceptInvitation(username, invitationID);

            // \LATER\ teamID is an argument here in case we want to notify the invitation sender later that this user will attend
        }

        public void DeclineInvitation(string username, int invitationID)
        {
            IInvitationsHandler invitationsHandler = new InvitationsHandler();
            invitationsHandler.DeclineInvitation(username, invitationID);

            // \LATER\ teamID is an argument here in case we want to notify the invitation sender later that this user will not attend
        }

    }
}
