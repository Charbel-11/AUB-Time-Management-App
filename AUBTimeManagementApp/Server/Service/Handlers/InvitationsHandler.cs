using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Service.Handlers
{
    public class InvitationsHandler: IInvitationsHandler
    {
        InvitationsStorage _invitationsStorage;
        public List<int> GetInvitationsEventsIds(int userId)
        {

            return null;
        }
        
        public void AcceptInvitation(int userId, int eventId)
        {
            // ...
            _invitationsStorage.RemoveInvitation(userId, eventId);
        }

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        public void DeclineInvitation(int userId, int eventId)
        {
            // ...
            _invitationsStorage.RemoveInvitation(userId, eventId);
        }
        public void SendInvitations(List<int> AttendeesUserIds, int eventId, string senderUsername)
        {
            foreach (int _userId in AttendeesUserIds)
            {
                _invitationsStorage.AddInvitation(_userId, eventId, senderUsername);
            } 
            
        }
    }
}
