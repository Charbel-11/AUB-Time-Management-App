using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface IInvitationsConnector
    {
        void AcceptInvitation(string username, int invitationID);
        void DeclineInvitation(string username, int invitationID);
    }
}
