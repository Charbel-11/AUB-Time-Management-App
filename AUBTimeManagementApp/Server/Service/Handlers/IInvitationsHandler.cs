using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    interface IInvitationsHandler
    {
        // This is called when a user wants to check his/her invitations
        // It should return a list of eventsIds
        List<int> GetInvitationsEventsIds(int userId);
        // This is called when the user accepts an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void AcceptInvitation(int userId, int eventId);

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void DeclineInvitation(int userId, int eventId);

        // Invite users to a certain event
        void SendInvitations(List<int> AttendeesUserIds, int eventId, string SenderUsername);
    }
}
