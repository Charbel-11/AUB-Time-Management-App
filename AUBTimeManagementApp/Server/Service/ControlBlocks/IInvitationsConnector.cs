using Server.DataContracts;
using System;
using System.Collections.Generic;

namespace Server.Service.ControlBlocks
{
    public interface IInvitationsConnector
    {
        List<Invitation> GetInvitationsDetails(string username);
        void AcceptInvitation(string username, int eventID, int teamID, string senderUsername);
        void DeclineInvitation(string username, int eventID, int teamID, string senderUsername);
    }
}
