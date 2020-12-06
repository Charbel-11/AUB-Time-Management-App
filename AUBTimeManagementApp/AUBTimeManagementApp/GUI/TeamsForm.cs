using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.GUI {
    public partial class TeamsForm : Form {
        //Maps each button to a team object
        Dictionary<Button, Team> butToTeam;

        /// <summary>
        /// Displays all the teams initially
        /// </summary>
        public TeamsForm() {
            Client.Client.Instance.setForm(this);
            butToTeam = new Dictionary<Button, Team>();
            InitializeComponent();
            displayAllUserTeams();
            addTeamButton.BringToFront();
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="m1">Title of the message</param>
        /// <param name="m2">Content of the message</param>
        public void showMessage(string m1, string m2) {
            MessageForm mB = new MessageForm(m1, m2);
            mB.Show();
        }

        /// <summary>
        /// Displays all the teams for the current user
        /// </summary>
        public void displayAllUserTeams() {
            butToTeam.Clear();
            List<Team> userTeams = Client.Client.Instance.getTeams();
            foreach (Team team in userTeams) { addTeamEntry(team); }
        }

        /// <summary>
        /// Adds a new team
        /// </summary>
        public void addTeamEntry(Team team) {
            Button newB = new Button();
            newB.Margin = new Padding(0);
            newB.Text = team.teamName;
            newB.Size = new Size(485, 46);
            newB.Click += teamInfo_Click;
            TeamsLayout.Controls.Add(newB);
            butToTeam[newB] = team;
       }

        /// <summary>
        /// Opens the addTeam panel
        /// </summary>
        private void addTeamButton_Click(object sender, EventArgs e) {
            AddTeam aT = new AddTeam();
            aT.Show();
        }

        /// <summary>
        /// Go back to the main menu
        /// </summary>
        private void backButton_Click(object sender, EventArgs e) {
            mainForm mF = new mainForm();
            mF.Show();
            Client.Client.Instance.GetUserSchedule();
            Close();
        }

        /// <summary>
        /// Opens the team info of one specific team
        /// </summary>
        private void teamInfo_Click(object sender, EventArgs e) {
            Team curTeam = butToTeam[(Button)sender];

            TeamDetailsForm tDF = new TeamDetailsForm(curTeam);
            tDF.Show();
            Close();
        }
    }
}
