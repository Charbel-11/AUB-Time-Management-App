using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Service.Teams
{
    class TeamsHandler
    {
        #region Requests
        //admin is the user who called the function
        //Returns the team for the user, null if an error occured
        public Team createTeamRequest(string admin, string teamName, string[] members, out string[] invalidUsernames)
        {
            //Get the usernames of members with valid username
            //Invalid usernames are stored in invalidUsernames
            //Create the team with the valid usernames/teamName/admin
            //Send the details for online users

            invalidUsernames = new string[1];
            return null;
        }

        public bool removeTeamRequest(int teamID)
        {
            //Get the team members
            //Delete the team from the database
            //Remove the teamID from each members' teams in the database
            //Notify online team members

            return false;
        }
               
        public bool addMemberRequest(string userToAdd, int teamID)
        {
            //Checks that the username exists
            //Get the team members
            //Add username to the team
            //Send an add member flag to online users

            return false;
        }

        public bool removeMemberRequest(string userToRemove, int teamID)
        {
            //Get the team members
            //Remove the username from the team
            //Send a remove member flag to online users

            return false;
        }

        public bool makeAdminRequest(string newAdmin, int teamID)
        {
            //Set the user as a new admin in the Teams Storage
            //Get the team members
            //Send a new admin flag to online users

            return false;
        }

        public bool removeAdminRequest(string oldAdmin, int teamID)
        {
            //Set the user as a normal member in the Teams Storage
            //Get the team members
            //Send a removed admin flag to online users

            return false;
        }

        public Team[] getPersonalTeams(string username)
        {
            //Gets all team IDs for the user
            //Then all the information for each team and send them back

            return null;
        }

        //Same as remove member when the member is the user himself, used like this for readability
        public bool leaveTeamRequest(string username, int teamID)
        {
            return removeMemberRequest(username, teamID);
        }
        #endregion

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

        public void receiveNewAdminFlag(string newAdmin, int teamID)
        {
            //newAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }

        public void receiveRemoveAdminFlag(string oldAdmin, int teamID)
        {
            //oldAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }
        #endregion
    }
}
