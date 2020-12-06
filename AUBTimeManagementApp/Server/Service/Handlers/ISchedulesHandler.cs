using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers {
    public interface ISchedulesHandler {

        /// <summary>
        /// change the priority of the event in isUserAttendee table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="username"></param>
        /// <param name="priority"></param>
        void updateUserEventPriority(int eventID, string username, int priority);

        /// <summary>
        /// Get a list of event IDs that the user is attending
        /// </summary>
        /// <returns>The list of event IDs</returns>
        List<int> GetUserSchedule(string userID);

        /// <summary>
        /// Add an event with eventID and priority specified by the user to a user's schedule 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventID"></param>
        /// <param name="priority"></param>
        void AddEventToUserSchedule(string username, int eventID, int priority);

        /// <summary>
        /// Remove an event with eventID from a user's schedule
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventID"></param>
        void RemoveEventFromUserSchedule(string username, int eventID);

        /// <summary>
        /// Change the priority of a team event in isTeamAttendee
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="teamID"></param>
        /// <param name="priority"></param>
        void updateTeamEventPriority(int eventID, int teamID, int priority);

        /// <summary>
        ///Get a team's schedule as a list of events IDs
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns>List of eventIDs of the events in the team's schedule</returns>
        List<int> GetTeamSchedule(int teamID);

        /// <summary>
        /// add (teamID, eventID, priority) to isTeamAttendee 
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="eventID"></param>
        /// <param name="priority"></param>
        void AddEventToTeamSchedule(int teamID, int eventID, int priority);

        /// <summary>
        /// Merges schedules of team members for one week, 
        /// where the schedules of the users contain events of a specified minima priority
        /// </summary>
        /// <param name="events"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="priorityThreshold"></param>
        /// <returns>an array of time slots showing the frequency of events for every slot</returns>
        double[,] getMergedScheduleFreq(List<List<Event>> events, DateTime startTime, DateTime endTime, int priorityThreshold);
    }
}
