using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using Server.DataContracts;


namespace Server.Service.Handlers {
    public class SchedulesHandler : ISchedulesHandler{
        #region userSchedule
        /// <summary>
        /// change the priority of the event in isUserAttendee table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="username"></param>
        /// <param name="priority"></param>
        public void updateUserEventPriority(int eventID, string username, int priority)
        {
            SchedulesStorage.UpdateUserEventPrioriy(eventID, username, priority);
        }


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

        public void updateTeamEventPriority(int eventID, int teamID, int priority)
        {
            SchedulesStorage.UpdateTeamEventPrioriy(eventID, teamID, priority);
        }

        public List<int> GetTeamSchedule(int teamID)
        {
            //get a list of event IDs that are scheduled for this team
            List<int> eventList = SchedulesStorage.GetTeamSchedule(teamID);
            Console.WriteLine("Getting the team schedule!");
            return eventList;
        }

        public void AddEventToTeamSchedule(int teamID, int eventID, int priority)
        {
            SchedulesStorage.AddToTeamSchedule(teamID, eventID, priority);
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

            return MergeSchedules(schedules, startTime, endTime, priorityThreshold);
        }

        /// <summary>
        /// Merges many schedules over 1 week
        /// </summary>
        /// <param name="membersSchedule"> Schedules to merge </param>
        /// <param name="startDate"> First Day of the week to be merged </param>
        /// <param name="endDate"> Last Day of the week to be merged </param>
        /// <param name="priorityThreshold">Threshold priority of events to be considered </param>
        /// <returns> A table showing how many events overlap at any given time in that week </returns>
        private double[,] MergeSchedules(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate, int priorityThreshold) {
            double[,] mergedSchedule = new double[7, 24 * 60]; 

            foreach (Schedule curSchedule in membersSchedule) {
                int i = 0;
                for (DateTime curDate = startDate; curDate.CompareTo(endDate) <= 0; curDate = curDate.AddDays(1), i++) {
                    int day = curDate.Day, month = curDate.Month, year = curDate.Year;
                    List<Event> events = curSchedule.getDailyEvent(day, month, year);
                    int[] userResult = new int[24 * 60 + 1];
                    
                    foreach (Event curEvent in events) {
                        if (curEvent.priority < priorityThreshold) { continue; }
                        DateTime eventStart = curEvent.startTime;
                        DateTime eventEnd = curEvent.endTime;
                        int startHour = eventStart.Hour, startMinute = eventStart.Minute; 
                        int endHour = eventEnd.Hour, endMinute = eventEnd.Minute;

                        int startIndex = 60 * startHour + startMinute;
                        int endIndex = 60 * endHour + endMinute;
                        userResult[startIndex]++;
                        userResult[endIndex + 1]--;
                    }

                    for (int j = 1; j < 24 * 60; j++) userResult[j] += userResult[j - 1];
                    for (int j = 0; j < 24 * 60; j++) mergedSchedule[i, j] += (userResult[j] != 0) ? 1 : 0;
                }
            }

            int n = membersSchedule.Count;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 24 * 60; j++)
                    mergedSchedule[i, j] /= n;

            return mergedSchedule;
        }

        #endregion
    }
}
