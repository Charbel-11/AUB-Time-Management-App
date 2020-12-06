using System;
using System.Collections.Generic;

namespace AUBTimeManagementApp.DataContracts {
    public class Event {
        public int ID { get; set; }
        public int priority { get; set; }
        public string plannerUsername { get; set; }
        public string eventName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string link { get; set; }
        public bool teamEvent { get; set; } //false if not a team event
        public Event(int _ID, int _priority, string _planner,
            string _eventName, DateTime _startTime, DateTime _endTime, bool _teamEvent = false, string _link = " ") {
            ID = _ID;
            eventName = _eventName;
            priority = _priority;
            plannerUsername = _planner;
            startTime = _startTime;
            endTime = _endTime;
            teamEvent = _teamEvent;
            link = _link;
        }

        public Event(int _ID)
        {
            ID = _ID;
        }
    }
}
