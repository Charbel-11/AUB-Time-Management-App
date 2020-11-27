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
    public partial class AddEvent : Form
    {
        /* To avoid creating 2 forms: one to create personal events and the other to create team events
         * Differentiate between both by the type of the parent form
         * Add 2 constructors
         */

        mainForm parent;
        TeamCalendarForm teamParent;
        public AddEvent(mainForm _parent)
        {
            parent = _parent;
            teamParent = null;
            InitializeComponent();

            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now.AddMinutes(30);
        }

        public AddEvent(TeamCalendarForm _parent)
        {
            parent = null;
            teamParent = _parent;
            InitializeComponent();

            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now.AddMinutes(30);
        }

        public AddEvent(mainForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            startDate.Value = _startDate;
            endDate.Value = _endDate;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Client.Client.Instance.showEvent(0,eventName.Text, priority.Value, startDate.Value, endDate.Value);
            if (parent == null)
            {
                Client.Client.Instance.CreateTeamEvent(teamParent.team.teamID, eventName.Text, priority.Value, startDate.Value, endDate.Value);
            }
            else
            {
                Client.Client.Instance.CreatePersonalEvent(eventName.Text, priority.Value, startDate.Value, endDate.Value);
            }
            Close();
        }
    }
}
