using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;
using AUBTimeManagementApp.GUI;
using System.Windows.Forms;
using System.Linq;

namespace AUBTimeManagementApp.Client
{
    public sealed class Client
    {
        private static readonly Client instance = new Client(); //Singleton

        private static readonly string serverIP = "127.0.0.1";
        private static readonly int serverPort = 8020;

        public string username;
        public string userID = "i";
        public int teamID = 0;
        private List<Team> teams;   //Might need to make it thread safe (consider case where members of same team add other members or delete or ..., we get asynchronous requests to change teams)
        private List<Event> events;

        //Connects the users to the active open form
        public RegistrationForm registrationForm { get; private set; }
        public mainForm mainForm { get; private set; }
        public SignInUpForm signInUpForm { get; private set; }
        public TeamsForm teamsForm { get; private set; }
        public TeamDetailsForm teamDetailsForm { get; private set; }

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
            else if (form.GetType() == typeof(TeamDetailsForm)) {
                teamDetailsForm = (TeamDetailsForm)form;
            }
        }

        public List<Team> getTeams() { return teams; }

        public void addEvent(Event newEvent) {
            events.Add(newEvent);
        }

        public void showEvent(string eventName, int priority, DateTime startDate, DateTime endDate) {
            mainForm.displayEvent(eventName, priority, startDate, endDate);
        }


        public void createAccount(string username, string firstName, string lastName, string password, string confirmPassword, string email, DateTime dateOfBirth) {            
            this.username = username;
            ClientTCP.PACKAGE_Register(username, firstName, lastName, password, confirmPassword, email, dateOfBirth);
        }
        public void registerReply(int OK) {
            if (registrationForm.InvokeRequired) {
                //We are calling a method of the form from a different thread
                //Need to use invoke to make it threadsafe
                registrationForm.Invoke(new MethodInvoker(delegate { registrationForm.registrationReply(OK); }));
            }
            else { registrationForm.registrationReply(OK); }
        }

        public void logIn(string username, string password) {
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

        #region Team
        public void createTeam(string teamName, string[] teamMembers) {
            ClientTCP.PACKAGE_CreateTeam(teamName, username, teamMembers);
        }
        public void createTeamReply(bool OK, string[] invalidUsernames) {
            string title = OK ? "The team was successfully created!" : "There was an error, the team was not created";
            string info = "";
            if (OK) {
                if (invalidUsernames.Length == 0) { info = "All usernames provided were valid."; }
                else {
                    info = "The following provided usernames were invalid:\r\n";
                    info += String.Join(", ", invalidUsernames);
                }
            }

            if (teamsForm != null && teamsForm.Visible) {
                if (teamsForm.InvokeRequired) {
                    teamsForm.Invoke(new MethodInvoker(delegate { teamsForm.showMessage(title, info); }));
                }
                else { teamsForm.showMessage(title, info); }
            }
        }

        public void addedToATeam(string teamName, int teamID, List<string> admins, List<string> members) {
            Team newTeam = new Team(teamID, teamName);
            foreach (string m in members) { newTeam.addMember(m); }
            foreach(string a in admins) { newTeam.addAdmin(a); }
            teams.Add(newTeam);

            if (teamsForm != null && teamsForm.Visible) {
                if (teamsForm.InvokeRequired) {
                    teamsForm.Invoke(new MethodInvoker(delegate { teamsForm.addTeamEntry(newTeam); }));
                }
                else { teamsForm.addTeamEntry(newTeam); }
            }
        }

        /// <summary>
        /// Sets username in team teamID to be either admin (if admin true) or not
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">The username of the member to set/unset as admin</param>
        /// <param name="isNowAdmin">True if we want to set the member as admin, false if we want to set him as member</param>
        public void changeAdminState(int teamID, string username, bool isNowAdmin) {
            ClientTCP.PACKET_ChangeAdminState(teamID, username, isNowAdmin);
        }

        /// <summary>
        /// Called when the user receives a notification that some admin state was changed in some team they are in
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">The username of the member that was set/unset as admin</param>
        /// <param name="isNowAdmin">True if the member is now an admin, false otherwise</param>
        public void adminStateChanged(int teamID, string username, bool isNowAdmin) {
            int idx = teams.FindIndex(a => a.teamID == teamID);
            if (idx == -1) { return; }

            if (isNowAdmin) { teams[idx].teamAdmin.Add(username); }
            else { teams[idx].teamAdmin.Remove(username); }

            if (teamDetailsForm != null && teamDetailsForm.Visible && teamDetailsForm.team.teamID == teamID) {
                if (teamDetailsForm.InvokeRequired) {
                    teamDetailsForm.Invoke(new MethodInvoker(delegate { teamDetailsForm.tryUpdatingTeam(); }));
                }
                else { teamDetailsForm.tryUpdatingTeam(); }
            }
        }
        
        /// <summary>
        /// Remove a member from a team
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">The member to remove (could be the current user)</param>
        public void removeMember(int teamID, string username) {
            ClientTCP.PACKET_RemoveMember(teamID, username);
        }

        /// <summary>
        /// Called when the user receives a notification that some member of a team they are in was removed
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">Tge username of the removed member</param>
        public void memberRemoved(int teamID, string username) {
            int idx = teams.FindIndex(a => a.teamID == teamID);
            if (idx == -1) { return; }

            bool teamDetailsOpen = teamDetailsForm != null && teamDetailsForm.Visible && teamDetailsForm.team.teamID == teamID;
            if (username == this.username) { 
                teams.RemoveAt(idx); 
                if (teamDetailsOpen) {
                    if (teamDetailsForm.InvokeRequired) {
                        teamDetailsForm.Invoke(new MethodInvoker(delegate { teamDetailsForm.goBack(); }));
                    }
                    else { teamDetailsForm.goBack(); }
                }
            }
            else {
                teams[idx].removeMember(username);
                if (teamDetailsOpen) {
                    if (teamDetailsForm.InvokeRequired) {
                        teamDetailsForm.Invoke(new MethodInvoker(delegate { teamDetailsForm.tryUpdatingTeam(); }));
                    }
                    else { teamDetailsForm.tryUpdatingTeam(); }
                }
            }
        }

        /// <summary>
        /// Adds a member to a team
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">The username of the user to add to the team</param>
        public void addMember(int teamID, string username) {
            ClientTCP.PACKET_AddMember(teamID, username);
        }

        /// <summary>
        /// Feedback of a request of the user made to add a member to a team
        /// </summary>
        /// <param name="OK">True if the member was added, false otherwise</param>
        public void addMemberReply(bool OK) {
            string feedback = (OK ? "Member added" : "The username is not valid");
            bool teamDetailsOpen = teamDetailsForm != null && teamDetailsForm.Visible && teamDetailsForm.team.teamID == teamID;
            if (teamDetailsOpen) {
                if (teamDetailsForm.InvokeRequired) {
                    teamDetailsForm.Invoke(new MethodInvoker(delegate { teamDetailsForm.addMemberFeedback(feedback); }));
                }
                else { teamDetailsForm.addMemberFeedback(feedback); }
            }
        }

        /// <summary>
        /// Called when the user receives a notification that some member of a team they are in was added
        /// </summary>
        /// <param name="teamID">The ID of the team</param>
        /// <param name="username">Tge username of the addd member</param>
        public void memberAdded(int teamID, string username) {
            int idx = teams.FindIndex(a => a.teamID == teamID);
            if (idx == -1) { return; }

            teams[idx].addMember(username);
            bool teamDetailsOpen = teamDetailsForm != null && teamDetailsForm.Visible && teamDetailsForm.team.teamID == teamID;
            if (teamDetailsOpen) {
                if (teamDetailsForm.InvokeRequired) {
                    teamDetailsForm.Invoke(new MethodInvoker(delegate { teamDetailsForm.tryUpdatingTeam(); }));
                }
                else { teamDetailsForm.tryUpdatingTeam(); }
            }
        }

        #endregion

        public void GetUserSchedule()
        {
            ClientTCP.PACKAGE_GetUserSchedule(userID);
        }

        public void GetUserScheduleReply(int n, List<Event> eventsList)
		{

		}

        public void GetTeamSchedule()
        {
            ClientTCP.PACKAGE_GetTeamSchedule(teamID);
        }

        public void GetTeamScheduleReply(int n, List<Event> eventsList)
        {

        }


        public void FilterUserSchedule(int priority, bool greaterThan, bool lessThan, bool equalTo)
        {
            ClientTCP.PACKAGE_FilterUserSchedule(userID, priority);
        }

        public void FilterUserScheduleReply(int n, List<Event> eventsList)
        {

        }


        public void FilterTeamSchedule(int priority)
        {
            ClientTCP.PACKAGE_FilterTeamSchedule(teamID, priority);
        }

        public void FilterTeamScheduleReply(int n, List<Event> eventsList)
        {

        }
    }
}
