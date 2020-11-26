using System.Collections.Generic;

namespace Server.Service.Handlers
{
    interface IInvitationsHandler
    {
        // This is called when a user wants to check his/her invitations
        // It should return a list of eventsIds
        List<int> GetInvitationsEventsIds(int userID);
        // This is called when the user accepts an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void AcceptInvitation(string username, int eventID, string senderUsername);

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void DeclineInvitation(string username, int eventID, string senderUsername);

        // Invite users to a certain event
        void SendInvitations(List<int> AttendeesUserIDs, int eventID, string SenderUsername);
    }
}
