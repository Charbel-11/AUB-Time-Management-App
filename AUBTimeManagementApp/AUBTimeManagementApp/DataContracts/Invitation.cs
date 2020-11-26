using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUBTimeManagementApp.DataContracts
{
    public class Invitation
    {
        Event Event;
        string InvitationSender;
        int TeamID;
        public Invitation(Event _event, string invitationSender, int teamID)
        {
            Event = _event;
            InvitationSender = invitationSender;
            TeamID = teamID;
        }
    }
}
