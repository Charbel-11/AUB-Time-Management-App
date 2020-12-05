using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface IInvitationsConnector
    {
        Event AcceptInvitation(string username, int invitationID, int eventID, int teamID);
        void DeclineInvitation(string username, int invitationID);
    }
}
