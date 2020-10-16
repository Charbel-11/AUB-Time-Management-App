using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Service.Teams
{
    class TeamsHandler
    {
        #region Requests
        //admin is the user who called the function
        //Returns the team for the user, null if an error occured
        public Team CreateTeamRequest(string admin, string teamName, string[] members, out string[] invalidUsernames)
        {
            //Get the usernames of members with valid username
            //Invalid usernames are stored in invalidUsernames
            //Create the team with the valid usernames/teamName/admin
            //Send the details for online users
        }

        public bool RemoveTeamRequest(int teamID)
        {
            //Get the team members
            //Delete the team from the database
            //Remove the teamID from each members' teams in the database
            //Notify online team members
        }

        public bool AddMemberRequest(string userToAdd, int teamID)
        {
            //Checks that the username exists
            //Get the team members
            //Add username to the team
            //Send an add member flag to online users
        }

        public bool RemoveMemberRequest(string userToRemove, int teamID)
        {
            //Get the team members
            //Remove the username from the team
            //Send a remove member flag to online users
        }

        public bool MakeAdminRequest(string newAdmin, int teamID)
        {
            //Set the user as a new admin in the Teams Storage
            //Get the team members
            //Send a new admin flag to online users
        }

        public bool RemoveAdminRequest(string oldAdmin, int teamID)
        {
            //Set the user as a normal member in the Teams Storage
            //Get the team members
            //Send a removed admin flag to online users
        }

        public Team[] GetPersonalTeams(string username)
        {
            //Gets all team IDs for the user
            //Then all the information for each team and send them back
        }

        //Same as remove member when the member is the user himself, used like this for readability
        public bool LeaveTeamRequest(string username, int teamID)
        {
            RemoveMemberRequest(username, teamID);
        }
        #endregion

        #region Send Flags
        private void SendNewTeamDetails(string username, Team team)
        {
            //Checks if the user is online
            //If so, send the team details
        }

        private void SendRemoveTeamFlag(string username, int teamID)
        {
            //Checks if the user is online
            //If so, remove the team with ID teamID from his teams
        }

        private void SendAddMemberFlag(string username, string newMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new member's username with the corresponding teamID
        }

        private void SendRemoveMemberFlag(string username, string removedMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the removed member's username with the corresponding teamID
        }

        private void SendNewAdminFlag(string username, string newAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new admin's username with the corresponding teamID
        }

        private void SendRemoveAdminFlag(string username, string oldAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the old admin's username with the corresponding teamID
        }
        #endregion

        #region Receive Flags
        public void ReceiveNewTeamDetails(Team team)
        {
            //Modify user's teams array + front end accordingly
        }

        public void ReceiveRemoveTeamFlag(int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public void ReceiveAddMemberFlag(string newMember, int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public void ReceiveRemoveMemberFlag(string removedMember, int teamID)
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
