using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;
using AUBTimeManagementApp.Service;
using AUBTimeManagementApp.Service.Teams;
using AUBTimeManagementApp.Service.Events;


namespace AUBTimeManagementApp.Client
{
    public sealed class Client
    {
        private static readonly Client instance = new Client(); //Singleton

        private static readonly string serverIP = "127.0.0.1";
        private static readonly int serverPort = 8020;

        public string username;
        private Schedule schedule;
        private List<Team> teams;
        private List<Event> events; 
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Client()
        {

        }
    
        //Constructor executed once the first time Client is used
        private Client()
        {
            teams = new List<Team>();
            events = new List<Event>();
        }
        public static Client Instance
        {
            get
            {
                return instance;
            }
        }

        public void initializeSocket() {
            ClientHandleData.InitializePacketListener();
            ClientTCP.InitializeClientSocket(serverIP, serverPort);
        }

        public void createAccount(string username, string password, string email)
        {
            if(username == "Charbel") { return; }
            
            //TODO
            this.username = username;
        }

        public KeyValuePair<bool, string> logIn(string username, string password)
        {
            //TODO
            this.username = username;

            // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH
            // Nourhane
            //      return ClientHandleData.HandleLogin(username, password);
            return new KeyValuePair<bool, string>(true, "SS");
            // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH
        }

        public void logOut()
        {

        }

        public void changePassword(string oldPassword, string oldPasswordCheck, string newPassword)
        {

        }
        public void createTeam(string teamName, string[] teamMembers) {
            TeamsHandler.createTeamRequest(username, teamName, teamMembers, out string[] invalidUsernames);
        }

        public void addTeam(Team newTeam)
        {
            teams.Add(newTeam);
        }

        public void createEvent(string eventname, int priority, DateTime startDate, DateTime endDate)
		{
            EventsHandler.createPersonalEvent(eventname, priority, startDate, endDate);
		}
        public void addEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        public string findFreeTime()
        {
            string s = "Find free time: \r\n All the time except: \r\n";
            foreach (Event e in events)
            {
                DateTime start, end;
                start = e.getStart();
                end = e.getEnd();
                s += start + "->" + end + "\r\n";
            }
            return s;
        }
    }

}
