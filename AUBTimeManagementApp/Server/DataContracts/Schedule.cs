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

        public void addEvent(Event _event){
            DateTime startDate = _event.startTime, endDate = _event.endTime;

            while (startDate.CompareTo(endDate) <= 0) {
                events[startDate.Year - 2000, startDate.Month - 1, startDate.Day - 1].Add(_event);
                startDate = startDate.AddDays(1);
            }
        }

        public List<Event> getDailyEvent(int day, int month, int year)
        {
            Console.WriteLine((year - 2000) + " " + (month - 1) + " " + (day - 1));
            return events[year - 2000, month - 1, day - 1];
        }
    }
}
