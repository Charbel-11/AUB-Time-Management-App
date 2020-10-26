using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;
using AUBTimeManagementApp.Service;
using AUBTimeManagementApp.Service.Teams;
using AUBTimeManagementApp.Service.Events;
using AUBTimeManagementApp.GUI;
using System.Windows.Forms;

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

        //Connects the users to the active open form
        private RegistrationForm registrationForm;
        private Form1 mainForm;
        private Form2 signInUpForm;

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

        //Stores a pointer to the currently opened in Client
        public void setForm(Form form) { 
            if (form.GetType() == typeof(RegistrationForm)) {
                registrationForm = (RegistrationForm)form;
            }
            else if (form.GetType() == typeof(Form1)) {
                mainForm = (Form1)form;
            }
            else if (form.GetType() == typeof(Form2)) {
                signInUpForm = (Form2)form;
            }
        }

        public void createAccount(string username, string password, string email)
        {
            if(username == "Charbel") { return; }
            
            //TODO
            this.username = username;
        }

        public void logIn(string username, string password)
        {
            this.username = username;
            ClientTCP.PACKAGE_Login(username, password);
        }
        public void logInReply(bool OK) {
            if (signInUpForm.InvokeRequired) {
                //We are calling a method of the form from a different thread
                //Need to use invoke to make it threadsafe
                signInUpForm.Invoke(new MethodInvoker(delegate { signInUpForm.loginReply(OK); }));
            }
            else { signInUpForm.loginReply(OK); }
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
