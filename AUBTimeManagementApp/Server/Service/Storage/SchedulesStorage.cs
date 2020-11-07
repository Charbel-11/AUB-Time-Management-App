using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class SchedulesStorage
    {
        public static bool ScheduleExists(string UserID)
        {
            return true;
        }
        
        public static bool AddToSchedule(string UserID, int EventID)
        {
            return true;
        }

        public static bool DelFromSchedule(string UserID, int EventID)
        {
            return true;
        }

        public static int[] GetSchedule(string UserID)
		{
            return new int[] {1,2,3};
		}

		public static bool CreateSchedule(string UserID, int[] EventsID = null)
		{
            return true;
		}

    }
}
