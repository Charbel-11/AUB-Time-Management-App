﻿using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using Server.DataContracts;


namespace Server.Service.Handlers {
    public class SchedulesHandler : ISchedulesHandler{
        #region userSchedule

        /// <summary>
        /// Get a list of event IDs that the user is attending
        /// </summary>
        /// <returns>The list of event IDs</returns>
        public List<int> GetUserSchedule(string username) {
            List<int> eventList = SchedulesStorage.GetUserSchedule(username);
            Console.WriteLine("Getting the user schedule!");
            return eventList;
        }

        public void AddEventToUserSchedule(string username, int eventID, int priority) {
            SchedulesStorage.AddToUserSchedule(username, eventID, priority);          
		}

        public void RemoveEventFromUserSchedule(string username, int eventID) {
            //gets username abd event ID
            //when user cancels event remove it from his schedule
            SchedulesStorage.DeleteFromUserSchedule(username, eventID);
        }

        #endregion

        #region teamSchedule

        public List<int> GetTeamSchedule(int teamID)
        {
            //get a list of event IDs that are scheduled for this team
            List<int> eventList = SchedulesStorage.GetTeamSchedule(teamID);
            Console.WriteLine("Getting the team schedule!");
            return eventList;
        }

        public void AddEventToTeamSchedule(int teamID, int eventID)
        {
            SchedulesStorage.AddToTeamSchedule(teamID, eventID);
        }

        public void RemoveEventFromTeamSchedule(int teamID, int eventID)
        {
            //gets username abd event ID
            //when user cancels event remove it from his schedule
            SchedulesStorage.DeleteFromTeamSchedule(teamID, eventID);
        }
        public double[,] getMergedScheduleFreq(List<List<Event>> events, DateTime startTime, DateTime endTime, int priorityThreshold) {
            List<Schedule> schedules = new List<Schedule>();
            foreach(List<Event> memberEvent in events) {
                Schedule curSchedule = new Schedule();
                foreach(Event e in memberEvent) {
                    curSchedule.addEvent(e);
                }
                schedules.Add(curSchedule);
            }

            return GetFreeTime(schedules, startTime, endTime, priorityThreshold);
        }

        /// <summary>
        /// Finds free time slots in multiple schedules
        /// <para> </para>
        /// </summary>
        /// <param name="membersSchedule"> Schedules to be merge </param>
        /// <param name="startDate"> First day of the week to be considered </param>
        /// <param name="endDate"> Last day of the week to be considered </param>
        /// <param name="priorityThreshold"> Threshold priority of events to be considered when merging schedules </param>
        /// <returns> A table showing the availability of each time slot (1->completely free; 0->completely busy)</returns>
        private double[,] GetFreeTime(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate, int priorityThreshold) {
            int[,] mergedSchedule = MergeSchedules(membersSchedule, startDate, endDate, priorityThreshold);
            double[,] result = new double[7, 24 * 60];

            int start = 0, end = 60 * 24;
            int n = membersSchedule.Count;

            for(int i = 0; i < 7; i++) {
                int j = start;
                while (j != end) { result[i, j]++; j++; }
            }

            for(int i = 0; i < 7; i++) {
                for(int j = 0;j < 24*60; j++) {
                    result[i, j] /= n;
                }
            }

            return result;
        }
        /// <summary>
        /// Merges many schedules over 1 week
        /// </summary>
        /// <param name="membersSchedule"> Schedules to merge </param>
        /// <param name="startDate"> First Day of the week to be merged </param>
        /// <param name="endDate"> Last Day of the week to be merged </param>
        /// <param name="priorityThreshold">Threshold priority of events to be considered </param>
        /// <returns> A table showing how many events overlap at any given time in that week </returns>
        private int[,] MergeSchedules(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate, int priorityThreshold)
        {
            int[,] mergedSchedule = new int[7, 24 * 60 + 1];
            foreach (Schedule curSchedule in membersSchedule)
            {
                int i = 0;
                for (DateTime curDate = startDate; curDate.CompareTo(endDate) <= 0; curDate.AddDays(1), i++)
                {
                    int day = curDate.Day, month = curDate.Month, year = curDate.Year;
                    List<Event> events = curSchedule.getDailyEvent(day, month, year);

                    foreach (Event curEvent in events)
                    {
                        if (curEvent.priority < priorityThreshold) { continue; }
                        DateTime eventStart = curEvent.startTime;
                        DateTime eventEnd = curEvent.endTime;
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

            return mergedSchedule;
        }

        #endregion
    }
}
