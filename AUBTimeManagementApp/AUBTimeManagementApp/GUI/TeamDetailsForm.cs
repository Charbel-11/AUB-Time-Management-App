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
    public partial class TeamDetailsForm : Form {
        public Team team { get; set; }
        List<Button> memberButtons, remButtons, adminButtons;
        List<Label> adminLabels;
        bool isAdmin;

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
                this.memberState.ForeColor = System.Drawing.Color.Black;
                addMembersButton.Enabled = false;
                scheduleEventBut.Enabled = false;
            }
            addMemberBox.Hide();
        }

        public void createMemberButton(string memberName) {
            System.Windows.Forms.GroupBox groupBox1 = new System.Windows.Forms.GroupBox();
            System.Windows.Forms.Button remBut = new System.Windows.Forms.Button();
            System.Windows.Forms.Button adminBut = new System.Windows.Forms.Button();
            System.Windows.Forms.Label adminLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Button memberBut = new System.Windows.Forms.Button();

            // 
            // remBut
            // 
            remBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            remBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            remBut.ForeColor = System.Drawing.Color.White;
            remBut.Location = new System.Drawing.Point(260, 4);
            remBut.Name = "remBut";
            remBut.Size = new System.Drawing.Size(87, 27);
            remBut.TabIndex = 4;
            remBut.Text = "Remove from Team";
            remBut.UseVisualStyleBackColor = false;
            remBut.Click += removeMember_Click;
            // 
            // adminBut
            // 
            adminBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            adminBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adminBut.ForeColor = System.Drawing.Color.White;
            adminBut.Location = new System.Drawing.Point(155, 4);
            adminBut.Name = "adminBut";
            adminBut.Size = new System.Drawing.Size(87, 27);
            adminBut.TabIndex = 3;
            adminBut.Text = "Dismiss as Admin";
            adminBut.UseVisualStyleBackColor = false;
            adminBut.Click += changeAdminState_Click;
            // 
            // adminLabel
            // 
            adminLabel.AutoSize = true;
            adminLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            adminLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            adminLabel.Location = new System.Drawing.Point(289, 12);
            adminLabel.Name = "adminLabel";
            adminLabel.Size = new System.Drawing.Size(36, 13);
            adminLabel.TabIndex = 2;
            adminLabel.Text = "Admin";
            // 
            // memberBut
            // 
            memberBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            memberBut.Location = new System.Drawing.Point(0, 0);
            memberBut.Name = "memberBut";
            memberBut.Size = new System.Drawing.Size(361, 34);
            memberBut.TabIndex = 1;
            memberBut.Text = memberName;
            memberBut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            memberBut.UseVisualStyleBackColor = true;
            memberBut.Click += membersButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(adminBut);
            groupBox1.Controls.Add(remBut);
            groupBox1.Controls.Add(adminLabel);
            groupBox1.Controls.Add(memberBut);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(361, 36);
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

        public void showTeamMembers() {
            flowLayoutPanel1.Controls.Clear();
            foreach (string member in team.teamMembers){
                createMemberButton(member);
            }
        }

        //If some member did a change to the team while we had it opened
        public void tryUpdatingTeam() {
            this.SuspendLayout();

            isAdmin = team.isAdmin(Client.Client.Instance.username);
            memberButtons.Clear();
            adminButtons.Clear();
            remButtons.Clear();
            adminLabels.Clear();

            this.teamName.Text = team.teamName;
            showTeamMembers();

            if (!isAdmin) {
                memberState.Text = "Member";
                this.memberState.ForeColor = System.Drawing.Color.Black;
                addMembersButton.Enabled = false;
                scheduleEventBut.Enabled = false;
            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void membersButton_Click(object sender, EventArgs e) {
            int idx = memberButtons.FindIndex(a => a == sender);
            if (!isAdmin || team.teamMembers[idx] == Client.Client.Instance.username) { return; }
            if (remButtons[idx].Visible) { remButtons[idx].Hide(); }
            else { remButtons[idx].Show(); }
            if (adminButtons[idx].Visible) { adminButtons[idx].Hide(); }
            else { adminButtons[idx].Show(); }
        }

        public void removeMember_Click(object sender, EventArgs e) {
            int idx = remButtons.FindIndex(a => a == sender);
            Client.Client.Instance.removeMember(team.teamID, team.teamMembers[idx]);
        }

        public void changeAdminState_Click(object sender, EventArgs e) {
            int idx = adminButtons.FindIndex(a => a == sender);
            Client.Client.Instance.changeAdminState(team.teamID, team.teamMembers[idx], !adminLabels[idx].Visible);
        }

        private void addMembersButton_Click(object sender, EventArgs e) {
            feedbackText.Text = "";
            buttonsBox.Hide();
            addMemberBox.Show();
        }

        private void scheduleEventBut_Click(object sender, EventArgs e) {

        }
        private void teamScheduleBut_Click(object sender, EventArgs e) {

        }

        private void leaveTeamBut_Click(object sender, EventArgs e) {
            Client.Client.Instance.removeMember(team.teamID, Client.Client.Instance.username);
        }

        private void backFromAddBut_Click(object sender, EventArgs e) {
            addMemberBox.Hide();
            buttonsBox.Show();
        }

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

        private void backBut_Click(object sender, EventArgs e) {
            goBack();
        }

        public void addMemberFeedback(string feedback) {
            feedbackText.Text = feedback;
        }

        public void goBack() {
            TeamsForm teamsF = new TeamsForm();
            teamsF.Show();
            Close();
        }
    }
}
