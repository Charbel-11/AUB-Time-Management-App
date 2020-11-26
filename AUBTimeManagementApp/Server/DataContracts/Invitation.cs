using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts
{
    public class Invitation
    {
        public Event Event { get; set; }
        public string InvitationSender { get; set; }
        public int TeamID { get; set; }
        public Invitation(Event _event, string invitationSender, int teamID)
        {
            Event = _event;
            InvitationSender = invitationSender;
            TeamID = teamID;
        }
    }
}
