using System;
using System.Collections.Generic;

namespace Server.DataContracts
{
    public class Schedule
    {
        public List<Event>[,,] events { get; set; } = new List<Event>[50, 12, 31];

        public Schedule() {
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 12; j++)
                    for (int k = 0; k < 31; k++)
                        events[i, j, k] = new List<Event>();           
        }

        /// <summary>
        /// Adds an event to the schedule class in the required format
        /// </summary>
        /// <param name="_event"> Event to be added </param>
        public void addEvent(Event _event){
            DateTime startDate = _event.startTime, endDate = _event.endTime;

            while (startDate.CompareTo(endDate) <= 0) {
                events[startDate.Year - 2000, startDate.Month - 1, startDate.Day - 1].Add(_event);
                startDate = startDate.AddDays(1);
            }
        }

        /// <summary>
        /// Returns the events on a specific day in the schedule
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Event> getDailyEvent(int day, int month, int year)
        {
            return events[year - 2000, month - 1, day - 1];
        }
    }
}
