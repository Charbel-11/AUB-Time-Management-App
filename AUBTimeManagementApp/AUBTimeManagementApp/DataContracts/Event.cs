using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AUBTimeManagementApp.DataContracts {
    public class Event {
        public int ID { get; set; }
        public int priority { get; set; }
        public string plannerUsername { get; set; }
        public string eventName { get; set; }
        public List<string> attendees { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public bool teamEvent { get; set; } //false if not a team event
        public Event(int _ID, int _priority, string _planner,
            string _eventName, DateTime _startTime, DateTime _endTime, bool _teamEvent = false, List<string> _attendees = null) {
            ID = _ID;
            eventName = _eventName;
            priority = _priority;
            plannerUsername = _planner;
            startTime = _startTime;
            endTime = _endTime;
            attendees = _attendees;
            teamEvent = _teamEvent;
        }

        public Event(int _ID)
        {
            ID = _ID;
        }
    }
}
