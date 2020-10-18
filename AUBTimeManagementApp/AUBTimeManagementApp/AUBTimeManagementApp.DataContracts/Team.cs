using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.AUBTimeManagementApp.DataContracts
{
    class Team
    {
        private int teamID;
        private string teamAdmin;
        private List<string> teamMembers;
        private Schedule teamSchedule;

        public Team(string _admin, int _teamID)
        {
            teamID = _teamID;
            teamAdmin = _admin;
            teamMembers = new List<string>();
            teamSchedule = new Schedule(false, "", _teamID);
        }
    }
}
