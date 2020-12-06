using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.GUI {
    public partial class TeamDetailsForm : Form {
        public Team team { get; set; }
        List<Button> memberButtons, remButtons, adminButtons;
        List<Label> adminLabels;
        bool isAdmin;

        /// <summary>
        /// Initializes the form with the team members and the buttons according to the user's admin state
        /// </summary>
        public TeamDetailsForm(Team _team) {
            Client.Client.Instance.setForm(this);
            InitializeComponent();

            team = _team;
            isAdmin = team.isAdmin(Client.Client.Instance.username);
            memberButtons = new List<Button>();
            adminButtons = new List<Button>();
            remButtons = new List<Button>();
            adminLabels = new List<Label>();

            this.teamName.Text = team.teamName;
            showTeamMembers();

            if (!isAdmin) {
                memberState.Text = "Member";
                this.memberState.ForeColor = Color.Black;
                addMembersButton.Enabled = false;
                scheduleEventBut.Enabled = false;
            }
            addMemberBox.Hide();
        }

        /// <summary>
        /// Creates a new group box in the gui for a team member
        /// </summary>
        /// <param name="memberName"></param>
        public void createMemberButton(string memberName) {
            GroupBox groupBox1 = new GroupBox();
            Button remBut = new Button();
            Button adminBut = new Button();
            Label adminLabel = new Label();
            Button memberBut = new Button();

            // 
            // remBut
            // 
            remBut.BackColor = SystemColors.ControlDarkDark;
            remBut.Font = new Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            remBut.ForeColor = Color.White;
            remBut.Location = new Point(260, 4);
            remBut.Name = "remBut";
            remBut.Size = new Size(87, 27);
            remBut.TabIndex = 4;
            remBut.Text = "Remove from Team";
            remBut.UseVisualStyleBackColor = false;
            remBut.Click += removeMember_Click;
            // 
            // adminBut
            // 
            adminBut.BackColor = SystemColors.ControlDarkDark;
            adminBut.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            adminBut.ForeColor = Color.White;
            adminBut.Location = new Point(155, 4);
            adminBut.Name = "adminBut";
            adminBut.Size = new Size(87, 27);
            adminBut.TabIndex = 3;
            adminBut.Text = "Dismiss as Admin";
            adminBut.UseVisualStyleBackColor = false;
            adminBut.Click += changeAdminState_Click;
            // 
            // adminLabel
            // 
            adminLabel.AutoSize = true;
            adminLabel.BackColor = SystemColors.ControlLight;
            adminLabel.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            adminLabel.Location = new Point(289, 12);
            adminLabel.Name = "adminLabel";
            adminLabel.Size = new Size(36, 13);
            adminLabel.TabIndex = 2;
            adminLabel.Text = "Admin";
            // 
            // memberBut
            // 
            memberBut.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            memberBut.Location = new Point(0, 0);
            memberBut.Name = "memberBut";
            memberBut.Size = new Size(361, 34);
            memberBut.TabIndex = 1;
            memberBut.Text = memberName;
            memberBut.TextAlign = ContentAlignment.MiddleLeft;
            memberBut.UseVisualStyleBackColor = true;
            memberBut.Click += membersButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(adminBut);
            groupBox1.Controls.Add(remBut);
            groupBox1.Controls.Add(adminLabel);
            groupBox1.Controls.Add(memberBut);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(361, 36);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;

            if (!team.isAdmin(memberName)) {
                adminLabel.Hide();
                adminBut.Text = "Set as Admin";
            }
            adminBut.Hide();
            remBut.Hide();

            this.flowLayoutPanel1.Controls.Add(groupBox1);
            memberButtons.Add(memberBut);
            adminButtons.Add(adminBut);
            remButtons.Add(remBut);
            adminLabels.Add(adminLabel);
        }

        /// <summary>
        /// Resets the team member box and adds the members again
        /// </summary>
        public void showTeamMembers() {
            flowLayoutPanel1.Controls.Clear();
            foreach (string member in team.teamMembers){
                createMemberButton(member);
            }
        }
        
        /// <summary>
        /// In case some changes happened to the team (e.g. added member, changed admin, ...)
        /// We reset the current panel to show these changes
        /// </summary>
        public void tryUpdatingTeam() {
            SuspendLayout();

            isAdmin = team.isAdmin(Client.Client.Instance.username);
            memberButtons.Clear();
            adminButtons.Clear();
            remButtons.Clear();
            adminLabels.Clear();

            teamName.Text = team.teamName;
            showTeamMembers();

            if (!isAdmin) {
                memberState.Text = "Member";
                memberState.ForeColor = Color.Black;
                addMembersButton.Enabled = false;
                scheduleEventBut.Enabled = false;
            }

            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Once we press on a member's group box, show/hide the related buttons
        /// </summary>
        public void membersButton_Click(object sender, EventArgs e) {
            int idx = memberButtons.FindIndex(a => a == sender);
            if (!isAdmin || team.teamMembers[idx] == Client.Client.Instance.username) { return; }
            if (remButtons[idx].Visible) { remButtons[idx].Hide(); }
            else { remButtons[idx].Show(); }
            if (adminButtons[idx].Visible) { adminButtons[idx].Hide(); }
            else { adminButtons[idx].Show(); }
        }
        /// <summary>
        /// Sets the GUI back to the initial buttons
        /// </summary>
        private void backFromAddBut_Click(object sender, EventArgs e) {
            addMemberBox.Hide();
            buttonsBox.Show();
        }

        /// <summary>
        /// Sends a request to the server to add a member to the team
        /// </summary>
        private void addBut_Click(object sender, EventArgs e) {
            string memberToAdd = textField.Text;
            if (memberToAdd == "") { return; }
            if (team.teamMembers.Contains(memberToAdd)) {
                feedbackText.Text = "This user is already a member of the team";
                return;
            }

            textField.Text = "";
            Client.Client.Instance.addMember(team.teamID, memberToAdd);
        }
        /// <summary>
        /// Shows the received feedback when trying to add a member
        /// </summary>
        public void addMemberFeedback(string feedback) {
            feedbackText.Text = feedback;
        }

        /// <summary>
        /// Sends a remove member request to the server
        /// </summary>
        public void removeMember_Click(object sender, EventArgs e) {
            int idx = remButtons.FindIndex(a => a == sender);
            // make sure the user wants to leave this team
            var result = MessageBox.Show("Are you sure you would like to Remove "+ team.teamMembers[idx]+ " from this team?",
                "Remove Member", MessageBoxButtons.YesNo);
            //If the yes button is pressed remove user from team
            if (result == DialogResult.Yes)
            {
                Client.Client.Instance.removeMember(team.teamID, team.teamMembers[idx]);
            }
        }

        /// <summary>
        /// Sends a change admin request to the server
        /// </summary>
        public void changeAdminState_Click(object sender, EventArgs e) {
            int idx = adminButtons.FindIndex(a => a == sender);
            Client.Client.Instance.changeAdminState(team.teamID, team.teamMembers[idx], !adminLabels[idx].Visible);
        }

        /// <summary>
        /// Shows the GUI to add a member
        /// </summary>
        private void addMembersButton_Click(object sender, EventArgs e) {
            feedbackText.Text = "";
            buttonsBox.Hide();
            addMemberBox.Show();
        }

        /// <summary>
        /// Opens the team's calendar with the merged schedule
        /// </summary>
        private void scheduleEventBut_Click(object sender, EventArgs e) {
            TeamCalendarForm newForm = new TeamCalendarForm(team, true);
            newForm.Show(); Close();
        }
        /// <summary>
        /// Opens the team's calendar
        /// </summary>
        private void teamScheduleBut_Click(object sender, EventArgs e) {
            TeamCalendarForm newForm = new TeamCalendarForm(team, false);
            newForm.Show(); Close();
        }

        /// <summary>
        /// Sends a request to the server to leave the team
        /// </summary>
        private void leaveTeamBut_Click(object sender, EventArgs e) {
            // make sure the user wants to leave this team
            var result = MessageBox.Show("Are you sure you would like to leave this team?",
                "Leave Team", MessageBoxButtons.YesNo);
            //If the yes button is pressed remove user from team
            if (result == DialogResult.Yes)
            {
                Client.Client.Instance.removeMember(team.teamID, Client.Client.Instance.username);
            }
           
        }

        /// <summary>
        /// Go back to the team selection screen
        /// </summary>
        private void backBut_Click(object sender, EventArgs e) {
            goBack();
        }
        /// <summary>
        /// Go back to the team selection screen
        /// </summary>
        public void goBack() {
            TeamsForm teamsF = new TeamsForm();
            teamsF.Show();
            Close();
        }
    }
}
