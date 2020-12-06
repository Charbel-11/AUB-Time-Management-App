using System;

namespace Server.DataContracts
{
    public class Event {
        public int eventID { get; set; }
        public int priority{get; set;}
        public string plannerUsername { get; set; }
        public string eventName { get; set; }
        public DateTime startTime { get; set; } 
        public DateTime endTime { get; set; }
        public bool teamEvent { get; set; } //false if not a team event
        public Event(int _eventID, int _priority, string _planner, 
            string _eventName, DateTime _startTime, DateTime _endTime, bool _teamEvent=false)
        {
            eventID = _eventID; 
            eventName = _eventName;
            priority = _priority;
            plannerUsername = _planner;
            startTime = _startTime;
            endTime = _endTime;
            teamEvent = _teamEvent;
        }
    }
}
