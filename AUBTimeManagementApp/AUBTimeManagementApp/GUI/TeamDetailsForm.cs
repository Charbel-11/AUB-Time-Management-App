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
        Team team;
        Dictionary<Button, int> memberButToIdx;
        List<Button> remButtons, adminButtons;
        List<Label> adminLabels;

        public TeamDetailsForm(Team _team) {
            InitializeComponent();

            team = _team;
            memberButToIdx = new Dictionary<Button, int>();
            adminButtons = new List<Button>();
            remButtons = new List<Button>();
            adminLabels = new List<Label>();

            this.teamName.Text = team.teamName;
            showTeamMembers();

            if (!team.isAdmin(Client.Client.Instance.username)) {
                memberState.Text = "Member";
                memberState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
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
            adminButtons.Add(adminBut);
            remButtons.Add(remBut);
            adminLabels.Add(adminLabel);
            memberButToIdx[memberBut] = adminLabels.Count - 1;
        }

        public void showTeamMembers() {
            flowLayoutPanel1.Controls.Clear();
            foreach (string member in team.teamMembers){
                createMemberButton(member);
            }
        }

        public void membersButton_Click(object sender, EventArgs e) {
            int idx = memberButToIdx[(Button)sender];
            if (remButtons[idx].Visible) { remButtons[idx].Hide(); }
            else { remButtons[idx].Show(); }
            if (adminButtons[idx].Visible) { adminButtons[idx].Hide(); }
            else { adminButtons[idx].Show(); }
        }

        private void addMembersButton_Click(object sender, EventArgs e) {

        }

        private void scheduleEventBut_Click(object sender, EventArgs e) {

        }

        private void teamScheduleBut_Click(object sender, EventArgs e) {

        }
    }
}
