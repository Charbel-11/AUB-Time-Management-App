using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AUBTimeManagementApp.Service.Teams;

namespace AUBTimeManagementApp.GUI
{
    public partial class AddTeam : Form
    {
        Form1 parent;

        public AddTeam(Form1 _parent)
        {
            parent = _parent;
            InitializeComponent();
        }

        private void AddTeam_Load(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            members.Text.Split(",");
            //TODO: Add the current user as admin
            TeamsHandler.createTeamRequest("me", teamName.Text, members.Text.Split(","), out string[] invalidUsernames);
            parent.displayTeam(teamName.Text, members.Text);
            Close();
        }
    }
}