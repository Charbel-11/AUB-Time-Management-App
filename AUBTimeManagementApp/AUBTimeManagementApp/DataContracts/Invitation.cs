
namespace AUBTimeManagementApp.DataContracts
{
    public class Invitation
    {
        public Event Event;
        public string InvitationSender;
        public int TeamID;
        public Invitation(Event _event, string invitationSender, int teamID)
        {
            Event = _event;
            InvitationSender = invitationSender;
            TeamID = teamID;
        }
    }
}
