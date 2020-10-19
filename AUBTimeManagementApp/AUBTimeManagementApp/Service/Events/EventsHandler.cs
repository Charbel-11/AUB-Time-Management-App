using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Service.Events
{
    static class EventsHandler    {
        static public Event createPersonalEvent(string eventname, int priority, DateTime startDate, DateTime endDate)
        {
            //check for conflict with the conflict checker
            //Create personal event with plannerUsername/priority/eventName/startTime/endTime
            //ask schedule hadler to update user's schedule (event list)


            Event newEvent = new Event(13, priority, "me", eventname, startDate, endDate);
            return null;
        }

        static public Event createTeamEvent()
        {
            //
            return null;
        }

        static public bool updatePersonalEvent()
		{
            // get event info to be updated (time, name, priority, attendees)
            //check for conflict with the conflict checker only if there is a time update
            //update event info in event storage if no time conflict
            return false;
		}

        static public bool cancelPersonalEvent()
		{
            //get ID of event to be canceled
            //remove event from event storage
            //send request to schedule handler to remove event from event list in user's schedule
            return false;
		}
      

        static public bool cancelTeamEvent()
		{
            //get ID of group event to be cancelled
            //get list of event attendees
            //ask schedules handler to remove event from events list of each of the attendees
            //delete event from event storage
            return false;
		}


    }
}
