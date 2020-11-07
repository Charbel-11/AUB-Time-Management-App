using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class EventsStorage
    {
        //Check if event exists
        public static bool eventExists(int eventID)
		{
            return true;
		}
        //Get event name
        public static string getEventName(int eventID)
        {
            string s = "";
            return s;
        }
        //Get event startDate
        public static DateTime getEventStartDate(int eventID)
        {
            DateTime start = new DateTime(2020,11,7);
            return start;
        }
        //Get event endDate
        public static DateTime getEventEndDate(int eventID)
        {
            DateTime end = new DateTime(2020, 11, 7);
            return end;
        }
        //Get event priority
        public static int getEventPriority(int eventID)
        {
            int priority = 0;
            return priority;
        }
        
    }
}
