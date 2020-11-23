using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.ControlBlocks
{
    public class TeamUsersConnector : ITeamUsersConnector
    {
        public List<string> CreateTeamRequest(string admin, string teamName, List<string> members)
        {
            List<string> areRegistered = new List<string>();
            List<string> invalidUsernames = new List<string>();

            // Check if a member has an account in the accounts DB
            IAccountsHandler _accountsHandler = new AccountsHandler();
            foreach (string member in members)
            {
                if (_accountsHandler.IsRegistered(member))
                {
                    areRegistered.Add(member);
                }
                else
                {
                    invalidUsernames.Add(member);
                }
            }
            //Note: No need to check if the admin is registered since he/she has already logged in
            // areRegistered are the team members with valid usernames
            // Now call the TeamsHandler to create the team
            
            if (areRegistered.Count == 0) return invalidUsernames; //TODO: should throw an exception or send the info somehow to the user
            
            ITeamsHandler _teamHandler = new TeamsHandler();
            _teamHandler.CreateTeamRequest(teamName, admin, areRegistered);

            return invalidUsernames;

        }

    }
}
