using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;
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
        public string userID;
        private List<Team> teams;
        private List<Event> events;

        //Connects the users to the active open form
        private RegistrationForm registrationForm;
        private mainForm mainForm;
        private SignInUpForm signInUpForm;
        private TeamsForm teamsForm;

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

        /// <summary>
        /// Stores a pointer to the currently opened form in Client
        /// </summary>
        /// <param name="form">The form to connect</param>
        public void setForm(Form form) { 
            if (form.GetType() == typeof(RegistrationForm)) {
                registrationForm = (RegistrationForm)form;
            }
            else if (form.GetType() == typeof(mainForm)) {
                mainForm = (mainForm)form;
            }
            else if (form.GetType() == typeof(SignInUpForm)) {
                signInUpForm = (SignInUpForm)form;
            }
            else if (form.GetType() == typeof(TeamsForm)) {
                teamsForm = (TeamsForm)form;
            }
        }

        public void createAccount(string username, string firstName, string lastName, string password, string confirmPassword, string email, DateTime dateOfBirth) {            
            //TODO
            this.username = username;
            ClientTCP.PACKAGE_Register(username, firstName, lastName, password, confirmPassword, email, dateOfBirth);
        }

        public void logIn(string username, string password) {
            this.username = username;
            ClientTCP.PACKAGE_Login(username, password);
        }

        public void registerReply(int OK) {
            if (registrationForm.InvokeRequired) {
                //We are calling a method of the form from a different thread
                //Need to use invoke to make it threadsafe
                registrationForm.Invoke(new MethodInvoker(delegate { registrationForm.registrationReply(OK); }));
            }
           else { registrationForm.registrationReply(OK); }
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
            
        }

        public void addTeam(Team newTeam)
        {
            teams.Add(newTeam);
        }

        public void showEvent(string eventName, int priority, DateTime startDate, DateTime endDate) {
            mainForm.displayEvent(eventName, priority, startDate, endDate);
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

        public void GetUserSchedule()
        {
            //get userID from user storage
            ClientTCP.PACKAGE_GetUserSchedule(userID);
        }
    }

}
