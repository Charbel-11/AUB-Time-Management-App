using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Service.Schedules
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

        public bool[,] mergeSchedule(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate, int countThreshold, int priorityThreshold, int startTime, int endTime)
        {
            bool[,] result = new bool[7, 24 * 60]; //!!!make sure it is initialized to ZERO!!!   
            int[,] mergedSchedule = new int[7, 24 * 60 + 1];

            foreach(Schedule curSchedule in membersSchedule)
            {
                int i = 0;
                for(DateTime curDate = startDate; curDate.CompareTo(endDate) <= 0; curDate.AddDays(1), i++)
                {
                    int day = curDate.Day, month = curDate.Month, year = curDate.Year;
                    List<Event> events = curSchedule.getDailyEvent(day, month, year);

                    foreach(Event curEvent in events)
                    {
                        DateTime start = curEvent.getStart();
                        DateTime end = curEvent.getEnd();
                        int startHour = start.Hour, startMinute = start.Minute;
                        int endHour = end.Hour, endMinute = end.Minute;

                        int startIndex = 60 * startHour + startMinute;
                        int endIndex = 60 * endHour + endMinute;
                        mergedSchedule[i, startIndex]++;
                        mergedSchedule[i, endIndex + 1]--;
                    }
                }
            }

            for (int i = 0; i < 7; i++)
                for (int j = 1; j < 24 * 60; j++)
                    mergedSchedule[i, j] += mergedSchedule[i, j - 1];



            return result;
        }
    }
}
