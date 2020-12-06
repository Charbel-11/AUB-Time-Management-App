using System;

namespace Server.DataContracts
{
    public class Event {
        public int eventID { get; set; } //identifies the event uniquely
        public int priority{get; set;} //Could be low, medium, high (0, 1, 2)
        public string plannerUsername { get; set; } //User who created the event
        public string eventName { get; set; }
        public DateTime startTime { get; set; } 
        public DateTime endTime { get; set; }
        public bool teamEvent { get; set; } //false if not a team event
        public string Link { get; set; }
        public Event(int _eventID, int _priority, string _planner,
            string _eventName, DateTime _startTime, DateTime _endTime, bool _teamEvent=false, string _link=" ")
        {
            eventID = _eventID; 
            eventName = _eventName;
            priority = _priority;
            plannerUsername = _planner;
            startTime = _startTime;
            endTime = _endTime;
            Link = _link;
            teamEvent = _teamEvent;
        }
    }
}
