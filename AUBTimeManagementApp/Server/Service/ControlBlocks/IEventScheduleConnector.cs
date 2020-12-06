using Server.DataContracts;
using System;
using System.Collections.Generic;


namespace Server.Service.ControlBlocks
{
    interface IEventScheduleConnector
    {
        /// <summary>
        /// Add the event to the events table and to add (eventId, username, priority) to isUserAttendee table
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventPriority"></param>
        /// <param name="plannerUsername"></param>
        /// <param name="eventName"></param>
        /// <param name="eventStart"></param>
        /// <param name="eventEnd"></param>
        /// <param name="isTeamEvent"></param>
        /// <returns> return a pair consisting of an event object containing the event details and a list of events that conflict the added event</returns>
        KeyValuePair<Event, List<Event>> AddUserEvent(string username, int eventPriority, string plannerUsername, string eventName, DateTime eventStart, DateTime eventEnd, bool isTeamEvent);


        /// <summary>
        /// if the event the user wants to remove from his schedule is a team event, then the (username,eventID) is removed from isUSerAttendee table
        /// else the event is removed from the events table and isUSerAttendee table
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eventID"></param>
        /// <param name="isTeamEvent"></param>
        void CancelUserEvent(string username, int eventID, bool isTeamEvent);


        /// <summary>
        /// update the event in events table and update its priority in the user's schedule in isUSerAttendee table
        /// </summary>
        /// <param name="updatedEvent"></param>
        /// <param name="username"></param>
        void ModifyUserEvent(Event updatedEvent, string username);

        
        /// <summary>
        /// get the details of an event with ID = eventID from events table
        /// gets the priority of the event in the user's schedule from isAttendee table
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="username"></param>
        /// <returns>Event object caontaining all the event details</returns>
        Event GetUserEventInDetail(int eventID, string username);

        /// <summary>
        /// get the list of events that the user is attending
        /// </summary>
        /// <param name="username"></param>
        /// <returns>list of event objects containing the details of the events teh user is attending</returns>
        List<Event> GetUserSchedule(string username);

        
        /// <summary>
        /// get the list of eventIDS that the team organized
        /// get a list of event objects with details of every event whose ID is in the list
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns>list of event objects containing event details that are organized by the team</returns>
        List<Event> GetTeamSchedule(int teamID);

        
        /// <summary>
        /// update the event in events table and update its priority in the team's schedule in isTeamAttendee table
        /// </summary>
        /// <param name="teamID"></param>
        /// <param name="updatedEvent"></param>
        void ModifyTeamEvent(int teamID, Event updatedevent);
    }
}
