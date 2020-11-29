using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts
{
    public class Invitation
    {
        public int invitationID { get; set; }
        public int eventID { get; set; }
        public int teamID { get; set; }
        public string senderUsername { get; set; }
        public Invitation(int _invitationID, int _eventID, int _teamID, string _senderUsername)
        {
            invitationID = _invitationID;
            eventID = _eventID;
            teamID = _teamID;
            senderUsername = _senderUsername;
        }
    }
}
