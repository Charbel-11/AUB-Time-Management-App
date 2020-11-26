using AUBTimeManagementApp.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI
{
    public partial class InvitationsForm : Form
    {
        mainForm _parent;
        public Dictionary<Button, Invitation> AcceptButtonToInvitation;
        public Dictionary<Button, Invitation> DeclineButtonToInvitation;
        public InvitationsForm(mainForm parent)
        {
            _parent = parent;
            AcceptButtonToInvitation = new Dictionary<Button, Invitation>();
            DeclineButtonToInvitation = new Dictionary<Button, Invitation>();
            InitializeComponent();
            DisplayInvitations();
            
        }

        public void DisplayInvitations()
        {
            AcceptButtonToInvitation.Clear();
            DeclineButtonToInvitation.Clear();
            List<Invitation> userInvitations = Client.Client.Instance.GetInvitations();
            foreach (Invitation invitation in userInvitations) { AddInvitationEntry(invitation); }
        }
        public void AddInvitationEntry(Invitation invitation)
        {

            GroupBox groupBox1 = new GroupBox();
            Button AcceptButton = new Button();
            Button DeclineButton = new Button();
            Label invitationLabel = new Label();

            // 
            // AcceptButton
            // 
            AcceptButton.BackColor = Color.LimeGreen;
            AcceptButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            AcceptButton.ForeColor = Color.White;
            AcceptButton.Location = new Point(155, 4);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(87, 27);
            AcceptButton.TabIndex = 4;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = false;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // DeclineButton
            // 
            DeclineButton.BackColor = Color.LightCoral;
            DeclineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            DeclineButton.ForeColor = System.Drawing.Color.White;
            DeclineButton.Location = new System.Drawing.Point(260, 4);
            DeclineButton.Name = "DeclineButton";
            DeclineButton.Size = new Size(87, 27);
            DeclineButton.TabIndex = 3;
            DeclineButton.Text = "Decline";
            DeclineButton.UseVisualStyleBackColor = false;
            DeclineButton.Click += DeclineButton_Click;
            // 
            // invitationLabel
            // 
            invitationLabel.AutoSize = true;
            invitationLabel.BackColor = SystemColors.ControlLight;
            invitationLabel.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            invitationLabel.Location = new Point(20, 4);
            invitationLabel.Name = "invitationLabel";
            invitationLabel.Size = new Size(36, 13);
            invitationLabel.TabIndex = 2;
            invitationLabel.Text = "Invitation";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(invitationLabel);
            groupBox1.Controls.Add(AcceptButton);
            groupBox1.Controls.Add(DeclineButton);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(361, 36);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;

            flowLayoutPanel1.Controls.Add(groupBox1);
            AcceptButtonToInvitation[AcceptButton] = invitation;
            DeclineButtonToInvitation[DeclineButton] = invitation;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {

        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {


        }

        private void InvitationButton_Click(object sender, EventArgs e)
        {

        }
    }
}
