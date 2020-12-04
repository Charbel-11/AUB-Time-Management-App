﻿using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers
{
    interface IInvitationsHandler
    {

        //returns a list of invitationIDs for a certain user
        List<int> GetInvitationsIDs(string username);

        // This is called when the user accepts an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void AcceptInvitation(string username, int invitationID);

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        void DeclineInvitation(string username, int invitationID);

        // Invite users to a certain event
        void SendInvitations(List<string> AttendeesUsernames, int eventID, int teamsID, string SenderUsername);

        List<Invitation> getInvitations(List<int> InvitationIDs);
    }
}
