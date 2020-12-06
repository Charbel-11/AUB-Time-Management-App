using System;
using System.Collections.Generic;

namespace AUBTimeManagementApp.DataContracts {
    public class Event {
        public int ID { get; set; } //Identifies event uniquely
        public int priority { get; set; } //Can be low, medium, high (0, 1, 2)
        public string plannerUsername { get; set; } //User who created the event
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
    }
}
