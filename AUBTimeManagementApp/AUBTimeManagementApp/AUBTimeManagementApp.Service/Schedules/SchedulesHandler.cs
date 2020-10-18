using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Service.Schedules
{
    class SchedulesHandler
    {
        public Schedule getUserSchedule(string username)
        {
            Schedule userSchedule = new Schedule(true, username);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return userSchedule;
        }

        public Schedule getTeamSchedule(int teamID)
        {
            Schedule teamSchedule = new Schedule(false, "", teamID);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return teamSchedule;
        }

        public Schedule getFilteredSchedule(string username, int priority)
        {
            //Get list of event IDs from the schedule storage
            //Get event details from the event handler
            //Filter the events with the filtering handler
            //Return filtered schedule

            return null;
        }


    }
}
