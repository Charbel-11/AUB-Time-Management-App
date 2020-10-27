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
        Form2 parent;
        public Form1(Form2 _parent, string username = null)
        {
            parent = _parent;
            Client.Client.Instance.setForm(this);

            InitializeComponent();
            label1.Text = "Welcome " + username + "!";
            label1.Show();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }
    }
}