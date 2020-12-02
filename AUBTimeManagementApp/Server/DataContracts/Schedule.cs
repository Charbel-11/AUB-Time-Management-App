using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.DataContracts
{
    public class Schedule
    {
        public List<Event>[,,] events { get; set; } = new List<Event>[50, 12, 31];

        public Schedule() { }

        public void addEvent(Event _event){
            DateTime startDate = _event.startTime, endDate = _event.endTime;

            while (startDate.CompareTo(endDate) <= 0) {
                events[startDate.Year, startDate.Month, startDate.Day].Add(_event);
                startDate.AddDays(1);
            }
        }

        public List<Event> getDailyEvent(int day, int month, int year)
        {
            return events[year, month, day];
        }
    }
}
