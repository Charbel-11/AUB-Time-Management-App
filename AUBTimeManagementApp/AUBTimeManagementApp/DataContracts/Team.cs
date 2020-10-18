using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUBTimeManagementApp.DataContracts
{   
    public class Team
    {
        private int teamID;
        private List<bool> teamAdmin;
        private List<string> teamMembers;
        private Schedule teamSchedule;

        public Team(string _admin, int _teamID)
        {
            teamID = _teamID;
            teamMembers = new List<string>(1); teamMembers.Append(_admin);
            teamAdmin = new List<bool>(1); teamAdmin.Append(true);
            teamSchedule = new Schedule(false, "", _teamID);
        }
    }
}
