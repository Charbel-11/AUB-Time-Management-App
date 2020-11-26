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
            // Adding an accept button
            Button newAccept = new Button();
            newAccept.Margin = new Padding(0);
            newAccept.Text = "Accept";
            newAccept.Size = new Size(485, 46);
            newAccept.Click += AcceptButton_Click;
            flowLayoutPanel1.Controls.Add(newAccept);
            AcceptButtonToInvitation[newAccept] = invitation;

            // Adding a decline button
            Button newDecline = new Button();
            newDecline.Margin = new Padding(0);
            newDecline.Text = "Decline";
            newDecline.Size = new Size(485, 46);
            newDecline.Click += DeclineButton_Click;
            flowLayoutPanel1.Controls.Add(newDecline);
            DeclineButtonToInvitation[newDecline] = invitation;
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
