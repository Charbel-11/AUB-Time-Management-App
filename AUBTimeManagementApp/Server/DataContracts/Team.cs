using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.DataContracts {
    public class Team {
        public int teamID { get; set; }
        public string teamName { get; set; }
        public List<string> teamAdmin { get; set; }
        public List<string> teamMembers { get; set; }

        public Team(int _teamID, string _teamName) {
            teamID = _teamID; teamName = _teamName;
            teamMembers = new List<string>();
            teamAdmin = new List<string>();
        }
        public void addMember(string username) {
            teamMembers.Add(username);
        }
        public void addAdmin(string username) {
            teamAdmin.Add(username);
        }
        public void removeMember(string username) {
            if (teamMembers.Contains(username)) { teamMembers.Remove(username); }
            if (teamAdmin.Contains(username)) { teamAdmin.Remove(username); }
        }
        public bool isAdmin(string username) { return teamAdmin.Contains(username); }

    }
}
