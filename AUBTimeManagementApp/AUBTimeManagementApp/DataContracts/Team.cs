using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUBTimeManagementApp.DataContracts
{   
    public class Team
    {
        private int teamID;
        private string teamName;
        private List<string> teamAdmin;
        private List<string> teamMembers;

        public Team(int _teamID, string _teamName)
        {
            teamID = _teamID; teamName = _teamName;
            teamMembers = new List<string>();
            teamAdmin = new List<string>();
        }

        public void addMember(string username, bool isAdmin) {
            teamMembers.Add(username);
            if (isAdmin) { teamAdmin.Add(username); }
        }

        public string getTeamName() { return teamName; }
        public string[] getMembers() { return teamMembers.ToArray(); }
        public bool isAdmin(string username) { return teamAdmin.Contains(username); }
    }
}
