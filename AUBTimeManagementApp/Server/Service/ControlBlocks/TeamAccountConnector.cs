using Server.DataContracts;
using Server.Service.Handlers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Server.Service.ControlBlocks
{
    public class TeamAccountConnector : ITeamAccountConnector {
        /// <summary>
        /// Checks for the validity of usernames, creates a new teams using the valid usernames and notifies online users
        /// </summary>
        /// <param name="ConnectionID">The connection ID of the calling user</param>
        /// <param name="admin">The admin of the team</param>
        /// <param name="teamName">The name of the team</param>
        /// <param name="members">A list of usernames to be checked for validity</param>
        public void createTeam(int ConnectionID, string admin, string teamName, List<string> members) {
            TeamsHandler teamsHandler = new TeamsHandler();
            AccountsHandler accountsHandler = new AccountsHandler();

            List<string> invalidUsernames = new List<string>();
            List<string> validUsernames = new List<string>();

            validUsernames.Add(admin);
            foreach (string m in members) {
                if (accountsHandler.IsRegistered(m)) { validUsernames.Add(m); }
                else { invalidUsernames.Add(m); }
            }

            int teamID = teamsHandler.CreateTeamRequest(admin, teamName, validUsernames);
            ServerTCP.PACKET_CreateTeamReply(ConnectionID, teamID != -1, invalidUsernames);
            if (teamID == -1) { return; }

            //Send the team details to online users         
            foreach (string user in validUsernames) {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_NewTeamCreated(cID, teamName, teamID, new string[] { admin }, validUsernames.ToArray());
            }
        }

        /// <summary>
        /// Adds a member to the team and notifies online users (if the username is valid)
        /// </summary>
        /// <param name="ConnectionID">Connection ID of the calling user, needed to give feedback</param>
        /// <param name="teamID">ID of the team</param>
        /// <param name="userToAdd">Username of the user to add to the team</param>
        public void addMember(int ConnectionID, int teamID, string userToAdd) {
            TeamsHandler teamsHandler = new TeamsHandler();
            AccountsHandler accountsHandler = new AccountsHandler();

            bool OK = accountsHandler.IsRegistered(userToAdd);
            if (OK) { teamsHandler.AddMemberRequest(teamID, userToAdd); }
            ServerTCP.PACKET_AddMemberReply(ConnectionID, teamID, OK);
            if (!OK) { return; }

            List<string> teamMembers = teamsHandler.GetTeamMembers(teamID);
            foreach (string user in teamMembers) {
                if (user == userToAdd) { continue; }
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                    ServerTCP.PACKET_MemberAdded(cID, teamID, userToAdd);
            }

            Team curTeam = teamsHandler.getTeamInfo(teamID);
            if (ServerTCP.UsernameToConnectionID.TryGetValue(userToAdd, out int ID))
                ServerTCP.PACKET_NewTeamCreated(ID, curTeam.teamName, teamID, curTeam.teamAdmin.ToArray(), curTeam.teamMembers.ToArray());
        }
    }
}
