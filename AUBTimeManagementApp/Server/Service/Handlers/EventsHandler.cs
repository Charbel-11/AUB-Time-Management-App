﻿using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Server.DataContracts;

namespace Server.Service.Handlers
{
    public class EventsHandler : IEventsHandler   {

        public EventsHandler()
        {

        }
        public Event CreatePersonalEvent(string eventname, int priority, DateTime startDate, DateTime endDate)
        {
            //check for conflict with the conflict checker
            //Create personal event with plannerUsername/priority/eventName/startTime/endTime
            //ask schedule hadler to update user's schedule (event list)

            //for prototype
           // Event newEvent = new Event(13, priority, "me", eventname, startDate, endDate);
           // Client.Client.Instance.addEvent(newEvent);
            return null;

        }

        public Event CreateTeamEvent()
        {
            //
            return null;
        }

        public bool UpdatePersonalEvent()
		{
            // get event info to be updated (time, name, priority, attendees)
            //check for conflict with the conflict checker only if there is a time update
            //update event info in event storage if no time conflict
            return false;
		}

        public bool CancelPersonalEvent()
		{
            //get ID of event to be canceled
            //remove event from event storage
            //send request to schedule handler to remove event from event list in user's schedule
            return false;
		}
      

        public bool CancelTeamEvent()
		{
            //get ID of group event to be cancelled
            //get list of event attendees
            //ask schedules handler to remove event from events list of each of the attendees
            //delete event from event storage
            return false;
		}

        public Event GetPersonalEvent(int eventID)
		{
            if (EventsStorage.eventExists(eventID))
            {
                string name = EventsStorage.getEventName(eventID);
                DateTime start = EventsStorage.getEventStartDate(eventID);
                DateTime end = EventsStorage.getEventEndDate(eventID);
                int priority = EventsStorage.getEventPriority(eventID);
                Event EventDetails = new Event(eventID,priority, "",name,start,end);
                return EventDetails;
            }
            return null;
		}
    }
}
