using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.DataContracts {
    public class Team {
        private int teamID { get; set; }
        private string teamName { get; set; }
        private List<string> teamAdmin { get; set; }
        private List<string> teamMembers { get; set; }

        public Team(int _teamID, string _teamName) {
            teamID = _teamID; teamName = _teamName;
            teamMembers = new List<string>();
            teamAdmin = new List<string>();
        }

        public void addMember(string username, bool isAdmin) {
            teamMembers.Add(username);
            if (isAdmin) { teamAdmin.Add(username); }
        }

        public bool isAdmin(string username) { return teamAdmin.Contains(username); }
    }
}
