using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.AUBTimeManagementApp.DataContracts
{
    class Schedule
    {
        private bool userSchedule;  //False if it is a team schedule
        private string usernameID;  //In case it is a user schedule
        private int teamID;         //In case it is a team schedule
        private List<Event> events;

        public Schedule(bool _userSchedule, string _usernameID, int _teamID = 0)
        {
            userSchedule = _userSchedule;
            usernameID = _usernameID;
            teamID = _teamID;
            events = new List<Event>();
        }
    }
}
