using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AUBTimeManagementApp.Client;

namespace AUBTimeManagementApp.GUI
{
    public partial class AddTeam : Form
    {
        public AddTeam()
        {
            Client.Client.Instance.setForm(this);
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e) {
            Client.Client.Instance.createTeam(teamName.Text, members.Text.Split(','));
            Close();
        }
    }
}