using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Service.Handlers
{
    public class InvitationsHandler: IInvitationsHandler
    {
        public List<int> GetInvitationsEventsIds(int userId)
        {

            return null;
        }
        
        // Sender username is a parameter in case later 2 admins can send 2 different invitations to same event
        public void AcceptInvitation(string username, int eventID, string senderUsername)
        {
            // Note that although Accept and Decline Invitation in this handler do the same thing: remove the invitation
            // We can't only use one function
            // Because we might lately decide to do more than just deleting (Maybe storing the accepted invitations)

            InvitationsStorage _invitationsStorage = new InvitationsStorage();
            _invitationsStorage.RemoveInvitation(username.GetHashCode(), eventID, senderUsername);
        }

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        public void DeclineInvitation(string username, int eventId, string senderUsername)
        {
            InvitationsStorage _invitationsStorage = new InvitationsStorage();
            _invitationsStorage.RemoveInvitation(username.GetHashCode(), eventId, senderUsername);
        }

        // This function asks the invitation storage to add invitations for invitees to an event
        public void SendInvitations(List<int> AttendeesUserIds, int eventId, string senderUsername)
        {
            foreach (int _userId in AttendeesUserIds)
            {
                InvitationsStorage _invitationsStorage = new InvitationsStorage();
                _invitationsStorage.AddInvitation(_userId, eventId, senderUsername);
            } 
            
        }
    }
}
