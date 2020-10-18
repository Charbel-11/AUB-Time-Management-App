using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Service.Schedules {
    class SchedulesHandler {
        public Schedule getUserSchedule(string username) {
            Schedule userSchedule = new Schedule(true, username);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return userSchedule;
        }

        public Schedule getTeamSchedule(int teamID) {
            Schedule teamSchedule = new Schedule(false, "", teamID);

            //Get a list of event IDs
            //Get the detail about each event and add it to a schedule

            return teamSchedule;
        }

        public Schedule getFilteredSchedule(string username, int priority) {
            //Get list of event IDs from the schedule storage
            //Get event details from the event handler
            //Filter the events with the filtering handler
            //Return filtered schedule

            return null;
        }

        /// <summary>
        /// Merges schedules of more than one user
        /// <para> </para>
        /// </summary>
        /// <param name="membersSchedule"> Schedules to be merge </param>
        /// <param name="startDate"> Starting day of the week to be merged </param>
        /// <param name="endDate"> Final day of the week to be merged </param>
        /// <param name="startTime">Starting time to show results</param>
        /// <param name="endTime"> Final time to show results </param>
        /// <param name="countThreshold"></param>
        /// <param name="priorityThreshold"></param>
        /// <returns></returns>
        public bool[,] mergeSchedule(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate, 
            DateTime startTime, DateTime endTime, int countThreshold, int priorityThreshold) {
            int[,] mergedSchedule = new int[7, 24 * 60 + 1];
            bool[,] result = new bool[7, 24 * 60];
            for(int i = 0; i < 7; i++)
                for(int j = 0; j < 24 * 60; j++) {
                    mergedSchedule[i, j] = 0;
                    result[i, j] = false;
                }

            foreach(Schedule curSchedule in membersSchedule) {
                int i = 0;
                for(DateTime curDate = startDate; curDate.CompareTo(endDate) <= 0; curDate.AddDays(1), i++) {
                    int day = curDate.Day, month = curDate.Month, year = curDate.Year;
                    List<Event> events = curSchedule.getDailyEvent(day, month, year);

                    foreach(Event curEvent in events) {
                        if(curEvent.getPriority() < priorityThreshold) { continue; }
                        DateTime eventStart = curEvent.getStart();
                        DateTime eventEnd = curEvent.getEnd();
                        int startHour = eventStart.Hour, startMinute = eventStart.Minute;
                        int endHour = eventEnd.Hour, endMinute = eventEnd.Minute;

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

            int start = 60 * startTime.Hour + startTime.Minute;
            int end = 60 * endTime.Hour + endTime.Minute;

            for(int i = 0; i < 7; i++) {
                int j = start, k = start;
                while(k != end + 1) {
                    if(mergedSchedule[i, j] >= countThreshold) { j++; k++; continue; }
                    if(mergedSchedule[i, k] < countThreshold) { k++; continue; }

                    while(j != k) { result[i, j] = true; j++; }
                }
                while (j != k) { result[i, j] = true; j++; }
            }

            return result;
        }
    }
}
