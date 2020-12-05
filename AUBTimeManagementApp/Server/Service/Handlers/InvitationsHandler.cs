using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers
{
    public class InvitationsHandler: IInvitationsHandler
    {
        public List<int> GetInvitationsIDs(string username)
        {
            List<int> invitationIDs = InvitationsStorage.GetUserInvitations(username);
            return invitationIDs;
        }
        
        // Sender username is a parameter in case later 2 admins can send 2 different invitations to same event
        public void AcceptInvitation(string username, int invitationID)
        {
            // Note that although Accept and Decline Invitation in this handler do the same thing: remove the invitation
            // We can't only use one function
            // Because we might lately decide to do more than just deleting (Maybe storing the accepted invitations)

            InvitationsStorage.RemoveUserInvitation(username, invitationID);
        }

        // This is called when the user declines an invitation
        // After finishing, the corresponding eventId should be removed from the DB
        public void DeclineInvitation(string username, int invitationID)
        {
            InvitationsStorage.RemoveUserInvitation(username, invitationID);
        }

        // This function asks the invitation storage to add invitations for invitees to an event
        public void SendInvitations(List<string> AttendeesUsernames, int eventID, int teamID, string senderUsername) {
            int invitationID = InvitationsStorage.AddInvitation(eventID, teamID, senderUsername, AttendeesUsernames.Count);
            foreach (string username in AttendeesUsernames)
            {
                if (username != senderUsername)
                {
                    InvitationsStorage.AddUserInvitation(username, invitationID);
                }
            }       
        }

        public List<Invitation> getInvitations(List<int> InvitationIDs) {
            return InvitationsStorage.GetInvitations(InvitationIDs);
        }
    }
}
