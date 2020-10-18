using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AUBTimeManagementApp.AUBTimeManagementApp.DataContracts
{
    class Event
    {
        int ID, duration, priority;
        string plannerUsername;
        List<string> attendees;
        List<DateTime> possibleStartingTimes;

        public Event(int _ID, int _duration, int _priority, 
            string _planner, List<DateTime> _startTimes, List<string> _attendees = null)
        {
            ID = _ID; duration = _duration;
            priority = _priority;
            plannerUsername = _planner;
            possibleStartingTimes = _startTimes;
            attendees = _attendees;
        }
    }
}
