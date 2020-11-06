using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.GUI {
    public partial class TeamsForm : Form {
        //Maps each button to a team object
        Dictionary<Button, Team> butToTeam;

        public TeamsForm() {
            Client.Client.Instance.setForm(this);
            butToTeam = new Dictionary<Button, Team>();
            InitializeComponent();
            displayAllUserTeams();
            addTeamButton.BringToFront();
        }

        public void showMessage(string m1, string m2) {
            MessageForm mB = new MessageForm(m1, m2);
            mB.Show();
        }

        public void displayAllUserTeams() {
            butToTeam.Clear();
            List<Team> userTeams = Client.Client.Instance.getTeams();
            foreach (Team team in userTeams) { addTeamEntry(team); }
        }

        public void addTeamEntry(Team team) {
            Button newB = new Button();
            newB.Margin = new Padding(0);
            newB.Text = team.getTeamName();
            newB.Size = new Size(485, 46);
            TeamsLayout.Controls.Add(newB);
            butToTeam[newB] = team;
        }

        private void addTeamButton_Click(object sender, EventArgs e) {
            AddTeam aT = new AddTeam();
            aT.Show();
        }

        private void backButton_Click(object sender, EventArgs e) {
            mainForm mF = new mainForm();
            mF.Show();
            Close();
        }
    }
}
