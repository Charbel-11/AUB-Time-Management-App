using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;
using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
