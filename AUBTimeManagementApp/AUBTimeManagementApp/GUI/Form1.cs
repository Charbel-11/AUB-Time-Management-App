using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void displayTeam(string newTeam, string newMembers)
        {
            teams.Text += "\r\n" + newTeam + ": " + newMembers;
        }

        public void displayEvent(string eventName, int priority, string startDate, string endDate)
        {
            events.Text += "\r\n" + eventName + ", " + priority + "\r\n"
                + startDate + " -> " + endDate;
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

        private void findTime_Click(object sender, EventArgs e)
        {
            freeTime.Text = (Client.Client.Instance.findFreeTime());
        }

    }
}