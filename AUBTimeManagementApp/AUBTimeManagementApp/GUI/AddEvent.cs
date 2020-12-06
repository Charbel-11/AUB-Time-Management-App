using System;
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
            setDateToDefault();
        }

        public AddEvent(TeamCalendarForm _parent)
        {
            parent = null;
            teamParent = _parent;
            InitializeComponent();
            setDateToDefault();
        }

        private void setDateToDefault() {
            DateTime startDate = new DateTime(), endDate = new DateTime();
            startDate = DateTime.Now;
            endDate = DateTime.Now.AddMinutes(30);

            datePickerStart.Value = startDate.Date;
            timePickerStart.Value = startDate.Date + startDate.TimeOfDay;
            datePickerEnd.Value = endDate.Date;
            timePickerEnd.Value = endDate.Date + endDate.TimeOfDay;
        }

        public AddEvent(mainForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            datePickerStart.Value = _startDate.Date;
            timePickerStart.Value = _startDate.Date + _startDate.TimeOfDay;
            datePickerEnd.Value = _endDate.Date;
            timePickerEnd.Value = _endDate.Date + _endDate.TimeOfDay;
        }

        public AddEvent(TeamCalendarForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            datePickerStart.Value = _startDate.Date;
            timePickerStart.Value = _startDate.Date + _startDate.TimeOfDay;
            datePickerEnd.Value = _endDate.Date;
            timePickerEnd.Value = _endDate.Date + _endDate.TimeOfDay;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value.Date + timePickerStart.Value.TimeOfDay;
            DateTime endDate = datePickerEnd.Value.Date + timePickerEnd.Value.TimeOfDay;
            if (parent == null)
            {
                Client.Client.Instance.CreateTeamEvent(teamParent.team.teamID, eventName.Text, priority.Value, startDate, endDate);
                Client.Client.Instance.showEvent(0, eventName.Text, priority.Value, startDate, endDate, true);
            }
            else
            {
                Client.Client.Instance.CreateUserEvent(eventName.Text, priority.Value, startDate, endDate);
                Client.Client.Instance.showEvent(0, eventName.Text, priority.Value, startDate, endDate, false);
            }
            Close();
        }
    }
}
