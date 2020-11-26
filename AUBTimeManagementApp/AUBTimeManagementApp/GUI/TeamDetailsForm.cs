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
        AddEvent addEventForm;
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

        public void showTeamMembers() {
            flowLayoutPanel1.Controls.Clear();
            foreach (string member in team.teamMembers){
                createMemberButton(member);
            }
        }

        //If some member did a change to the team while we had it opened
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
            if (addEventForm != null && addEventForm.Visible)
            {
                addEventForm.Focus();
                return;
            }
            addEventForm = new AddEvent(this);
            addEventForm.Show();
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
