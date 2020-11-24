using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    public interface ISchedulesHandler
    {
        List<int> GetUserSchedule(string userID);
        void AddEventToList(string username, int eventID);
        void RemoveEventFromList(string username, int eventID);
        List<int> GetTeamSchedule(int teamID);
        void AddEventToTeamList(int teamID, int eventID);
        void RemoveEventFromTeamList(int teamID, int eventID);
        bool[,] GetFreeTime(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate,
            DateTime startTime, DateTime endTime, int countThreshold, int priorityThreshold);
    }
}
