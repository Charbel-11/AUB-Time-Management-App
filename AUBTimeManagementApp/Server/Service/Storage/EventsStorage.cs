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
            string s = "event___1";
            return s;
        }
        //Get event startDate
        public static DateTime getEventStartDate(int eventID)
        {
            DateTime start;
            if (eventID==1){ start = DateTime.Now;}
            else if (eventID == 2) { start = new DateTime(2020, 11, 4, 8, 30, 52);}
            else { start = new DateTime(2020, 11, 12, 8, 30, 52);}
            return start;
        }
        //Get event endDate
        public static DateTime getEventEndDate(int eventID)
        {
            DateTime end;
            if (eventID == 1) { end = DateTime.Now; }
            else if (eventID == 2) { end = new DateTime(2020, 11, 4, 12, 30,52); }
            else { end = new DateTime(2020, 11, 12, 12, 30, 52); }
            return end;
        }
        //Get event priority
        public static int getEventPriority(int eventID)
        {
            int priority = 1;
            return priority;
        }
        
    }
}
