using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Service.Schedules
{
    class SchedulesHandler
    {
        public Schedule GetUserSchedule(string username)
        {
            Schedule userSchedule = new Schedule(true, username);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return userSchedule;
        }

        public Schedule GetTeamSchedule(int teamID)
        {
            Schedule teamSchedule = new Schedule(false, "", teamID);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return teamSchedule;
        }
    }
}
