using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts
{
    public class Invitation
    {
        public int invitationID { get; set; } //Identifies the invitations uniquely
        public int eventID { get; set; } //Event to which users are invited
        public int teamID { get; set; } //Team that initiated the invitation
        public string senderUsername { get; set; } //Admin that sent the invitation
        public Invitation(int _invitationID, int _eventID, int _teamID, string _senderUsername)
        {
            invitationID = _invitationID;
            eventID = _eventID;
            teamID = _teamID;
            senderUsername = _senderUsername;
        }
    }
}
