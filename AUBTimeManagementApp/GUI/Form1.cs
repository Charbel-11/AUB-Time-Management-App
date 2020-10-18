using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void addTeam(string newTeam, string newMembers)
        {
            teams.Text = teams.Text + "\r\n" + newTeam + ": " + newMembers;
        }

        public void addEvents(string eventName, int priority)
        {
            events.Text = events.Text + "\r\n" + eventName + ", " + priority;
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            AddTeam addTeamWindow = new AddTeam(this);
            addTeamWindow.Show();
        }

        private void addEvent_MouseClick(object sender, MouseEventArgs e)
        {
            AddEvent addEventWindow = new AddEvent(this);
            addEventWindow.Show();
        }
    }
}
