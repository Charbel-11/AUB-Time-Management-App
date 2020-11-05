using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AUBTimeManagementApp.Client;

namespace AUBTimeManagementApp.GUI
{
    public partial class AddTeam : Form
    {
        List<string> members;
        List<Button> removeButtons;
        List<GroupBox> grpBoxes;
        public AddTeam()
        {
            Client.Client.Instance.setForm(this);
            members = new List<string>();
            removeButtons = new List<Button>();
            grpBoxes = new List<GroupBox>();
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e) {
            Client.Client.Instance.createTeam(teamName.Text, members.ToArray());
            Close();
        }

        private void addButton_Click(object sender, EventArgs e) {
            string newMember = memberName.Text;
            memberName.Text = "";
            if (newMember == "") { return; }
            if (members.Contains(newMember)) { return; }

            Label nLabel = new Label();
            nLabel.Text = newMember;
            nLabel.AutoSize = true;
            nLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nLabel.Margin = new System.Windows.Forms.Padding(0);
            nLabel.Location = new System.Drawing.Point(5, 8);

            Button nBut = new Button();
            nBut.Margin = new System.Windows.Forms.Padding(0);
            nBut.Size = new System.Drawing.Size(62, 27);
            nBut.Location = new System.Drawing.Point(162,8);
            nBut.Text = "Remove";
            nBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            nBut.ForeColor = System.Drawing.Color.White;
            nBut.BringToFront();
            nBut.Click += removeButton_Click;

            GroupBox nGroupBox = new GroupBox();
            nGroupBox.Controls.Add(nLabel);
            nGroupBox.Controls.Add(nBut);
            nGroupBox.Margin = new System.Windows.Forms.Padding(0);
            nGroupBox.Size = new System.Drawing.Size(230, 36);

            flowLayoutPanel1.Controls.Add(nGroupBox);
            members.Add(newMember);
            removeButtons.Add(nBut);
            grpBoxes.Add(nGroupBox);
        }

        private void removeButton_Click(object sender, EventArgs e) {
            int idx = removeButtons.FindIndex(a => a == sender);

            members.RemoveAt(idx);
            removeButtons.RemoveAt(idx);
            flowLayoutPanel1.Controls.Remove(grpBoxes[idx]);
            grpBoxes.RemoveAt(idx);
        }
    }
}