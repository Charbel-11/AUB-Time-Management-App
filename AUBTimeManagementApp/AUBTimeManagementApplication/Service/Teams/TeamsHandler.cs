using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.Client;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Service.Teams
{
    static class TeamsHandler
    {
        #region Requests
        //admin is the user who called the function
        //Returns the team for the user, null if an error occured
        public static Team createTeamRequest(string admin, string teamName, string[] members, out string[] invalidUsernames)
        {
            //Get the usernames of members with valid username
            //Invalid usernames are stored in invalidUsernames
            //Create the team with the valid usernames/teamName/admin
            //Send the details for online users

            //For the prototype:
            Team newTeam = new Team(admin, 11);
            Client.Client.Instance.addTeam(newTeam);

            invalidUsernames = new string[1];
            return null;
        }

        public static bool removeTeamRequest(int teamID)
        {
            //Get the team members
            //Delete the team from the database
            //Remove the teamID from each members' teams in the database
            //Notify online team members

            return false;
        }
               
        public static bool addMemberRequest(string userToAdd, int teamID)
        {
            //Checks that the username exists
            //Get the team members
            //Add username to the team
            //Send an add member flag to online users

            return false;
        }

        public static bool removeMemberRequest(string userToRemove, int teamID)
        {
            //Get the team members
            //Remove the username from the team
            //Send a remove member flag to online users

            return false;
        }

        public static bool makeAdminRequest(string newAdmin, int teamID)
        {
            //Set the user as a new admin in the Teams Storage
            //Get the team members
            //Send a new admin flag to online users

            return false;
        }

        public static bool removeAdminRequest(string oldAdmin, int teamID)
        {
            //Set the user as a normal member in the Teams Storage
            //Get the team members
            //Send a removed admin flag to online users

            return false;
        }

        public static Team[] getPersonalTeams(string username)
        {
            //Gets all team IDs for the user
            //Then all the information for each team and send them back

            return null;
        }

        //Same as remove member when the member is the user himself, used like this for readability
        public static bool leaveTeamRequest(string username, int teamID)
        {
            return removeMemberRequest(username, teamID);
        }
        #endregion

        #region Send Flags
        private static void sendNewTeamDetails(string username, Team team)
        {
            //Checks if the user is online
            //If so, send the team details
        }

        private static void sendRemoveTeamFlag(string username, int teamID)
        {
            //Checks if the user is online
            //If so, remove the team with ID teamID from his teams
        }

        private static void sendAddMemberFlag(string username, string newMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new member's username with the corresponding teamID
        }

        private static void sendRemoveMemberFlag(string username, string removedMember, int teamID)
        {
            //Checks if the user is online
            //If so, send the the removed member's username with the corresponding teamID
        }

        private static void sendNewAdminFlag(string username, string newAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the new admin's username with the corresponding teamID
        }

        private static void sendRemoveAdminFlag(string username, string oldAdmin, int teamID)
        {
            //Checks if the user is online
            //If so, send the the old admin's username with the corresponding teamID
        }
        #endregion

        #region Receive Flags
        public static void receiveNewTeamDetails(Team team)
        {
            //Modify user's teams array + front end accordingly
        }

        public static void receiveRemoveTeamFlag(int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public static void receiveAddMemberFlag(string newMember, int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public static void receiveRemoveMemberFlag(string removedMember, int teamID)
        {
            //Modify user's teams array + front end accordingly
        }

        public static void receiveNewAdminFlag(string newAdmin, int teamID)
        {
            //newAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }

        public static void receiveRemoveAdminFlag(string oldAdmin, int teamID)
        {
            //oldAdmin could be equal to the client's username, we need to deal with that case
            //Otherwise, just modify the corresponding team
        }
        #endregion
    }
}
