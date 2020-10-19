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
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Client()
        {

        }
    
        //Constructor executed once the first time Client is used
        private Client()
        {
            teams = new List<Team>();
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

        public void logIn(string username, string password)
        {
            //TODO
            this.username = username;
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
    }
}
