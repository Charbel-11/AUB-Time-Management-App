using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers {
    public interface ISchedulesHandler {
        void RemoveEventFromSchedules(int eventID);
        void updatePriority(int eventID, string username, int priority);
        List<int> GetUserSchedule(string userID);
        void AddEventToUserSchedule(string username, int eventID, int priority);
        void RemoveEventFromUserSchedule(string username, int eventID);
        List<int> GetTeamSchedule(int teamID);
        void AddEventToTeamSchedule(int teamID, int eventID, int priority);
        void RemoveEventFromTeamSchedule(int teamID, int eventID);
        double[,] getMergedScheduleFreq(List<List<Event>> events, DateTime startTime, DateTime endTime, int priorityThreshold);
    }
}
