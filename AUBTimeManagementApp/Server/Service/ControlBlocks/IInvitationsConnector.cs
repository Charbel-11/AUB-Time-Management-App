using Server.DataContracts;

namespace Server.Service.ControlBlocks
{
    public interface IInvitationsConnector
    {
        // Accept invitation
        // (1) Add event to the user's schedule
        // (2) Remove inviation from the DB
        Event AcceptInvitation(string username, int invitationID, int eventID, int teamID);

        // Decline Invitation
        // Only remove invitation from the DB
        void DeclineInvitation(string username, int invitationID);

        //send invitations to newly added team member
        void InviteNewMemberToEvents(string username, int teamID);
    }
}
