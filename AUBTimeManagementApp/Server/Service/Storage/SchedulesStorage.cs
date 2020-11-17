using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class SchedulesStorage
    {
        /********************user schedule********************/

        /// <summary>
        /// check if user is atteding any event in isAttendee
        /// </summary>
        /// <returns> return true if found, return false otherwise</returns>
        public static bool PersonalScheduleExists(string UserID)
        {
            return true;
        }

        /// <summary>
        /// add eventID to user schedule with id = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool AddToPersonalSchedule(string UserID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// delete eventID from user schedule with ID = userID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool DelFromPersonalSchedule(string UserID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// Get list of event IDs from isAttendee with userID = username
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the user </returns>
        public static List<int> GetPersonalSchedule(string UserID)
		{
            return null;
		}


        /********************team schedule********************/

        /// <summary>
        /// check if team schedule with ID = teamID exists
        /// </summary>
        /// <returns> return true if found, return false otherwise</returns>
        public static bool TeamScheduleExists(int TeamID)
        {
            return true;
        }

        /// <summary>
        /// add eventID to team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool AddToTeamSchedule(int TeamID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// delete eventID from team schedule with ID = teamID
        /// </summary>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool DelFromTeamSchedule(int TeamID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// Get list of event IDs from team schedule with ID = teamID
        /// </summary>
        /// <returns> returns a list of IDs of all events in the schedule of the team </returns>
        public static List<int> GetTeamSchedule(int TeamID)
        {

            return null;
        }

    }
}
