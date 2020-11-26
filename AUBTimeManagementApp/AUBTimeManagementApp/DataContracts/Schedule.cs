
using System.Collections.Generic;

namespace AUBTimeManagementApp.DataContracts {
    public class Schedule {
        public bool userSchedule { get; set; }  //False if it is a team schedule
        public string usernameID { get; set; }  //In case it is a user schedule
        public int teamID { get; set; }         //In case it is a team schedule
        public List<Event>[,,] events { get; set; } = new List<Event>[50, 12, 31];

        public Schedule(bool _userSchedule, string _usernameID = "", int _teamID = 0) {
            userSchedule = _userSchedule;
            usernameID = _usernameID;
            teamID = _teamID;
        }

        public List<Event> getDailyEvent(int day, int month, int year) {
            return events[year, month, day];
        }
    }
}
