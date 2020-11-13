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
        List<int> GetTeamSchedule(int teamID);
        //int[] GetFilteredSchedule(string username, int priority);
        bool AddEventToList(string username, int eventID);
        bool RemoveEventFromList(string username, int eventID);
        bool[,] GetFreeTime(List<Schedule> membersSchedule, DateTime startDate, DateTime endDate,
            DateTime startTime, DateTime endTime, int countThreshold, int priorityThreshold);
    }
}
