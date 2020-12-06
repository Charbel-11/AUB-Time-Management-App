using System.Collections.Generic;

namespace Server.DataContracts {
    public class Team {
        public int teamID { get; set; } //Identifies the teams uniquely
        public string teamName { get; set; }
        public List<string> teamAdmin { get; set; }
        public List<string> teamMembers { get; set; }

        public Team(int _teamID, string _teamName, List<string> _admins, List<string> _members)
        {
            teamID = _teamID;
            teamName = _teamName;
            teamMembers = _members;
            teamAdmin = _admins;
        }
    }
}
