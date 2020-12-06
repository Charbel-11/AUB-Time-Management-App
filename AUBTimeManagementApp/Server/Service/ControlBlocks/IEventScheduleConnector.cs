using Server.DataContracts;
using System;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        // Add a user event
        // This function returns a pair containing the added event and a list of event objects
        // conflicting with the newly added event
        KeyValuePair<Event, List<Event>> AddUserEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd, bool isTeamEvent);
        
        // Cancel an event for a given user
        void CancelUserEvent(string username, int eventID, bool isTeamEvent);

        // Modify events details
        void ModifyUserEvent(Event updatedEvent, string username);

        // Get event details
        // Why do we pass username as parameter?
        // Mainly because the priority depends on the user
        Event GetUserEventInDetail(int eventID, string username);

        // Get list of events objects
        List<Event> GetEventsInDetail(string username);

        // Get the user schedule as a list of events objects
        List<Event> GetUserSchedule(string username);

        // Get the team schedule as a list of events objects
        List<Event> GetTeamSchedule(int teamID);

        // Update a team event
        void ModifyTeamEvent(int teamID, Event updatedevent);
    }
}
