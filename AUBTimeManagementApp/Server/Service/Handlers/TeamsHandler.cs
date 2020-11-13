using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.Service.Storage;
using Server.DataContracts;

namespace Server.Service.Handlers
{
    public class TeamsHandler: ITeamsHandler
    {
        #region Requests
        /// <summary>
        /// Creates a new team in the database and notifies all online users
        /// </summary>
        /// <param name="admin">The admin of the team (calling user)</param>
        /// <param name="teamName">The name of the team</param>
        /// <param name="members">The list of members given by the calling user (might be invalid)</param>
        public void CreateTeamRequest(int ConnectionID, string admin, string teamName, string[] members)
        {
            List<string> invalidUsernames = new List<string>();
            List<string> validUsernames = new List<string>();

            validUsernames.Add(admin);
            foreach(string m in members) {
                if (AccountsStorage.usernameExists(m)) { validUsernames.Add(m); }
                else { invalidUsernames.Add(m); }
            }

            //NOTE: Maybe generate the team ID automatically and return it in the addTeam function instead
            int teamID = TeamsStorage.getNewTeamID();
            bool OK = TeamsStorage.addTeam(teamName, admin, TeamsStorage.getNewTeamID(), validUsernames.ToArray());
            ServerTCP.PACKET_CreateTeamReply(ConnectionID, OK, invalidUsernames.ToArray());
            if (!OK) { return; }

            //Send the team details to online users         
            foreach (string user in validUsernames) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_NewTeamCreated(cID, teamName, teamID, admin, validUsernames.ToArray());
            }
        }

        public bool RemoveTeamRequest(int teamID)
        {
            //Get the team members
            //Delete the team from the database
            //Remove the teamID from each members' teams in the database
            //Notify online team members

            return false;
        }
               
        public bool AddMemberRequest(string userToAdd, int teamID)
        {
            //Checks that the username exists
            //Get the team members
            //Add username to the team
            //Send an add member flag to online users

            return false;
        }

        public bool RemoveMemberRequest(string userToRemove, int teamID)
        {
            //Get the team members
            //Remove the username from the team
            //Send a remove member flag to online users

            return false;
        }

        public bool MakeAdminRequest(string newAdmin, int teamID)
        {
            //Set the user as a new admin in the Teams Storage
            //Get the team members
            //Send a new admin flag to online users

            return false;
        }

        public bool RemoveAdminRequest(string oldAdmin, int teamID)
        {
            //Set the user as a normal member in the Teams Storage
            //Get the team members
            //Send a removed admin flag to online users

            return false;
        }

        public Team[] GetPersonalTeams(string username)
        {
            //Gets all team IDs for the user
            //Then all the information for each team and send them back

            return null;
        }

        //Same as remove member when the member is the user himself, used like this for readability
        public bool LeaveTeamRequest(string username, int teamID)
        {
            return RemoveMemberRequest(username, teamID);
        }
        #endregion

        //Those should probably be in the ServerTCP
        #region Send Flags
        private void sendNewTeamDetails(string username, Team team)
        {
            //Checks if the user is online
            //If so, send the team details
        }

        private void sendRemoveTeamFlag(string username, int teamID)
        {
            //Checks if the user is online
            //If so, remove the team with ID teamID from his teams
        }

        private void sendAddMemberFlag(string username, string newMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new member's username with the corresponding teamID
        }

        private void sendRemoveMemberFlag(string username, string removedMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the removed member's username with the corresponding teamID
        }

        private void sendNewAdminFlag(string username, string newAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new admin's username with the corresponding teamID
        }

        private void sendRemoveAdminFlag(string username, string oldAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the old admin's username with the corresponding teamID
        }
        #endregion

        //Those should be in the client code i guess
        #region Receive Flags
        public void receiveNewTeamDetails(Team team)
        {
            //Modify user's teams array + front end accordingly
        }

        public void receiveRemoveTeamFlag(int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public void receiveAddMemberFlag(string newMember, int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public void receiveRemoveMemberFlag(string removedMember, int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public void ReceiveNewAdminFlag(string newAdmin, int teamID)
        {
            //newAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }

        public void ReceiveRemoveAdminFlag(string oldAdmin, int teamID)
        {
            //oldAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }
        #endregion
    }
}
