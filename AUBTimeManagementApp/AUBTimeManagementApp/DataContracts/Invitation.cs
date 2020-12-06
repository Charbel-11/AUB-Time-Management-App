
namespace AUBTimeManagementApp.DataContracts
{
    public class Invitation
    {
        public int invitationID; //Identifies the invitation uniquely
        public Event Event; //Event for which users are invited
        public string InvitationSender; //Admin who sent the invitation
        public int TeamID; //Team that issued the invitation
        public Invitation(int _invitationID, Event _event, string invitationSender, int teamID)
        {
            invitationID = _invitationID;
            Event = _event;
            InvitationSender = invitationSender;
            TeamID = teamID;
        }
    }
}
