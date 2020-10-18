using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AUBTimeManagementApp.DataContracts
{
    class Event {
        private int ID, priority;
        private string plannerUsername, eventName;
        private List<string> attendees;
        private DateTime startTime, endTime;

        public Event(int _ID, int _priority, string _planner, 
            string _eventName, DateTime _startTime, DateTime _endTime, List<string> _attendees = null)
        {
            ID = _ID; 
            eventName = _eventName;
            priority = _priority;
            plannerUsername = _planner;
            startTime = _startTime;
            endTime = _endTime;
            attendees = _attendees;
        }

        public DateTime getStart()
        {
            return startTime;
        }
        public DateTime getEnd()
        {
            return endTime;
        }
        public int getPriority()
        {
            return priority;
        }
    }
}
