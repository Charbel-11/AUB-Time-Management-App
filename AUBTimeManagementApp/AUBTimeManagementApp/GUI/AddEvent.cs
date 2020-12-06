using System;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI
{
    public partial class AddEvent : Form
    {
        mainForm parent;
        TeamCalendarForm teamParent;

        /// <summary>
        /// Constructor used when addEvent was opened from the main calendar
        /// </summary>
        public AddEvent(mainForm _parent)
        {
            parent = _parent;
            teamParent = null;
            InitializeComponent();
            setDateToDefault();
        }
        /// <summary>
        /// Constructor used when addEvent was opened from a team calendar
        /// </summary>
        public AddEvent(TeamCalendarForm _parent)
        {
            parent = null;
            teamParent = _parent;
            InitializeComponent();
            setDateToDefault();
        }
        /// <summary>
        /// A constructor that opens the addEvent from the main calendar with start/end date set to some values
        /// </summary>
        public AddEvent(mainForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            datePickerStart.Value = _startDate.Date;
            timePickerStart.Value = _startDate.Date + _startDate.TimeOfDay;
            datePickerEnd.Value = _endDate.Date;
            timePickerEnd.Value = _endDate.Date + _endDate.TimeOfDay;
        }
        /// <summary>
        /// A constructor that opens the addEvent from a team calendar with start/end date set to some values
        /// </summary>
        public AddEvent(TeamCalendarForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            datePickerStart.Value = _startDate.Date;
            timePickerStart.Value = _startDate.Date + _startDate.TimeOfDay;
            datePickerEnd.Value = _endDate.Date;
            timePickerEnd.Value = _endDate.Date + _endDate.TimeOfDay;
        }

        /// <summary>
        /// Sets the date to the current date
        /// </summary>
        private void setDateToDefault() {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMinutes(30);

            datePickerStart.Value = startDate.Date;
            timePickerStart.Value = startDate.Date + startDate.TimeOfDay;
            datePickerEnd.Value = endDate.Date;
            timePickerEnd.Value = endDate.Date + endDate.TimeOfDay;
        }

        /// <summary>
        /// Sends a create event request to the server according to the user's input on the GUI
        /// </summary>
        private void createButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value.Date + timePickerStart.Value.TimeOfDay;
            DateTime endDate = datePickerEnd.Value.Date + timePickerEnd.Value.TimeOfDay;
            if (parent == null)
                Client.Client.Instance.CreateTeamEvent(teamParent.team.teamID, eventName.Text, priority.Value, startDate, endDate);
            else
                Client.Client.Instance.CreateUserEvent(eventName.Text, priority.Value, startDate, endDate);

            Close();
        }
    }
}
