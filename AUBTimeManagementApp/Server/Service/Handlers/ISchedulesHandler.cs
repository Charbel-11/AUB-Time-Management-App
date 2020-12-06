using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers {
    public interface ISchedulesHandler {
        // Change the priority of an event
        void updateUserEventPriority(int eventID, string username, int priority);

        // Get the user schedule as a list of events IDs
        List<int> GetUserSchedule(string userID);

        // Add an event with eventID to a user's schedule 
        // Note that the priority is not a property of the event only since the same event can be of high priority for some user 
        // and of low priority to another
        void AddEventToUserSchedule(string username, int eventID, int priority);

        // Remove an event with eventID from a user's schedule
        void RemoveEventFromUserSchedule(string username, int eventID);

        // Change the priority of a team event
        void updateTeamEventPriority(int eventID, int teamID, int priority);

        // Get a team's schedule as a list of events IDs
        List<int> GetTeamSchedule(int teamID);

        // Add an event with eventID to a team's schedule
        void AddEventToTeamSchedule(int teamID, int eventID, int priority);

        // Merges schedules of team members for one week and returns an array of time slots showing the frequency of events for every slot
        double[,] getMergedScheduleFreq(List<List<Event>> events, DateTime startTime, DateTime endTime, int priorityThreshold);
    }
}
