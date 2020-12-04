
namespace AUBTimeManagementApp.DataContracts
{
    public class Invitation
    {
        public int invitationID;
        public Event Event;
        public string InvitationSender;
        public int TeamID;
        public Invitation(int _invitationID, Event _event, string invitationSender, int teamID)
        {
            invitationID = _invitationID;
            Event = _event;
            InvitationSender = invitationSender;
            TeamID = teamID;
        }
    }
}
