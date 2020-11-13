using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class SchedulesStorage
    {
        /********************user schedule********************/

        /// <summary>
        /// check if user schedule with Id = userID exists
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns> return true if found, return false otherwise</returns>
        public static bool PersonalScheduleExists(string UserID)
        {
            return true;
        }

        /// <summary>
        /// add eventID to user schedule with id = userID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="EventID"></param>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool AddToPersonalSchedule(string UserID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// delete eventID from user schedule with ID = userID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="EventID"></param>
        /// <returns> return true if successful, false otherwise </returns>
        public static bool DelFromPersonalSchedule(string UserID, int EventID)
        {
            return true;
        }

        /// <summary>
        /// Get list of event IDs from user schedule with ID = userID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns> returns a list of IDs of all events in the schedule of the user </returns>
        public static int[] GetPersonalSchedule(string UserID)
		{
            return new int[] {1,2,3};
		}

        /// <summary>
        /// if a personal schedule with ID= userID, create one.
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="EventsID"></param>
        /// <returns> retunr true if successful, false otherwise </returns>
        public static bool CreatePersonalSchedule(string UserID, int[] EventsID = null)
		{
            return true;
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
        public static int[] GetTeamSchedule(int TeamID)
        {
            return new int[] { 1, 2, 3 };
        }

        /// <summary>
        /// if a team schedule with ID= teamID does not exist, create one.
        /// </summary>
        /// <returns> retunr true if successful, false otherwise </returns>
        public static bool CreateTeamSchedule(int TeamID, int[] EventsID = null)
        {
            return true;
        }
    }
}
