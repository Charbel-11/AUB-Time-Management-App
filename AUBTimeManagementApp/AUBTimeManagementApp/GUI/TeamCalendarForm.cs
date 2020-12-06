using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.GUI {
    public partial class TeamCalendarForm : Form {
        List<CalendarItem> _items = new List<CalendarItem>();
        public Team team { get; set; }
        public bool mergedCalendarShown { get; set; }
        CalendarItem selectedItem;
        AddEvent addEventForm;
        bool isAdmin;

        /// <summary>
        /// Initializes the team calendar, enabling buttons according to the admin state of the user
        /// </summary>
        /// <param name="_team">The team in question</param>
        /// <param name="merged">True if we want to display the merged schedule first, false if we want to display the team schedule</param>
        public TeamCalendarForm(Team _team, bool merged) {
            Client.Client.Instance.setForm(this);
            InitializeComponent();

            team = _team;
            teamNameLabel.Text = team.teamName;
            isAdmin = team.isAdmin(Client.Client.Instance.username);
            if (!isAdmin) {
                merged = false;
                addEventButton.Enabled = false;
                teamSchedButton.Enabled = true;
                mergedSchedButton.Enabled = false;
                memberState.Text = "Member";
                this.memberState.ForeColor = Color.Black;
            }
 
            calendar.AllowItemEdit = false;
            calendar.AllowItemResize = false;
            mergedCalendarShown = false;
            monthView.SelectionStart = monthView.SelectionEnd = DateTime.Today;
            mergedCalendarShown = merged;
            priorityBoxBackButton_Click(null, null);
            if (merged) { SubmitButton_Click(null, null); }
            else { teamSchedButton_Click(null, null); }
            eventDetailsPanel.Hide();
        }

        /// <summary>
        /// Called when we change dates in the monthView object
        /// </summary>
        private void monthView_SelectionChanged(object sender, EventArgs e) {
            if (mergedCalendarShown) {
                DateTime start = monthView.SelectionStart, end = monthView.SelectionEnd;
                if (end.Subtract(start).Days > 6) {
                    end = start.AddDays(6);
                    monthView.SelectionEnd = end;
                }
                Client.Client.Instance.GetMergedTeamSchedule(team.teamID, start, end, 0);
            }
            calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionEnd);
        }

        /// <summary>
        /// Used to add the items to the calendar again in case of reset
        /// </summary>
        private void PlaceItems() {
            foreach (CalendarItem item in _items) {
                if (calendar.ViewIntersects(item)) {
                    calendar.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Called when we need to load the calendar items
        /// </summary>
        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e) {
            PlaceItems();
        }

        /// <summary>
        /// Displays the merged schedule with colors, where red means most people are busy and white means most people are free
        /// </summary>
        /// <param name="freq">Shows at each time how many people are busy divided by the total number of people</param>
        public void displayColorFreq(double[,] freq) {
            int n = freq.GetLength(0), m = freq.GetLength(1);
            int R = 255;

            DateTime start = monthView.SelectionStart, end = monthView.SelectionEnd; //Maybe take those from the server
            calendar.Items.Clear(); _items.Clear();
            for (int i = 0; i < n; i++) {
                int firstJ = 0;
                while (firstJ < m) {
                    int j = firstJ;
                    while (j < m - 1 && freq[i, j] == freq[i, j + 1]) { j++; }
                    CalendarItem curItem = new CalendarItem(calendar);
                    DateTime curS = start; curS = curS.AddDays(i); curS = curS.AddMinutes(firstJ);
                    curItem.StartDate = curS;
                    curS = curS.AddMinutes(j - firstJ);
                    curItem.EndDate = curS;
                    int val = (int)(255 - 255 * freq[i, j]);
                    curItem.ApplyColor(Color.FromArgb(255, val, val));
                    calendar.Items.Add(curItem); _items.Add(curItem);

                    Console.WriteLine(curItem.StartDate.ToString() + " " + curItem.EndDate.ToString());
                    firstJ = j + 1;
                }
            }
        }

        /// <summary>
        /// Display an event on the calendar and color it according to its priority (1->blue; 2->green; 3->red)
        /// </summary>
        /// <param name="_event">The event in question</param>
        public void displayEvent(Event _event) {
            CalendarItem curEvent = new CalendarItem(calendar, _event.startTime, _event.endTime, _event.eventName, _event.ID, _event.priority, _event.teamEvent);
            calendar.Items.Add(curEvent); _items.Add(curEvent);
            int priority = curEvent.priority;
            if (priority == 1) { curEvent.BackgroundColor = curEvent.BackgroundColorLighter = Color.LightBlue; }
            else if (priority == 2) { curEvent.BackgroundColor = curEvent.BackgroundColorLighter = Color.LightGreen; }
            else { curEvent.BackgroundColor = curEvent.BackgroundColorLighter = Color.PaleVioletRed; }
        }
        
        /// <summary>
        /// Opens the add event form
        /// </summary>
        private void addEvent_Click(object sender, EventArgs e) {
            if (addEventForm != null && addEventForm.Visible) {
                addEventForm.Focus();
                return;
            }
            addEventForm = new AddEvent(this);
            addEventForm.Show();
        }

        /// <summary>
        /// Goes back to the team details form
        /// </summary>
        private void backButton_Click(object sender, EventArgs e) {
            TeamDetailsForm newForm = new TeamDetailsForm(team);
            newForm.Show(); Close();
        }

        /// <summary>
        /// Opens the team schedule after fetching the events from the server
        /// </summary>
        public void teamSchedButton_Click(object sender, EventArgs e) {
            mergedCalendarShown = false;
            calendar.Items.Clear(); _items.Clear();
            Client.Client.Instance.GetTeamSchedule(team.teamID);
            monthView_SelectionChanged(null, null);
        }

        /// <summary>
        /// Modifies the GUI to show the priority choice box
        /// </summary>
        private void mergedSchedButton_Click(object sender, EventArgs e) {
            priorityBox.Show();
            addEventButton.Hide();
            teamSchedButton.Hide();
            mergedSchedButton.Hide();
            backButton.Hide();
        }

        /// <summary>
        /// Modifies the GUI to show the initial buttons
        /// </summary>
        private void priorityBoxBackButton_Click(object sender, EventArgs e) {
            addEventButton.Show();
            teamSchedButton.Show();
            mergedSchedButton.Show();
            backButton.Show();
            priorityBox.Hide();
        }

        /// <summary>
        /// Submits the request to get the merged schedule from the server with a priority threshold
        /// </summary>
        public void SubmitButton_Click(object sender, EventArgs e) {
            mergedCalendarShown = true;
            DateTime start = monthView.SelectionStart, end = monthView.SelectionEnd;
            if (end.Subtract(start).Days > 6) {
                end = start.AddDays(7);
                monthView.SelectionEnd = end;
            }
            Client.Client.Instance.GetMergedTeamSchedule(team.teamID, start, end, ModifyPriority.Value);
            priorityBoxBackButton_Click(null, null);
            monthView_SelectionChanged(null, null);
        }

        /// <summary>
        /// When we double click on an event, its details are displayed
        /// </summary>
        private void calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e) {
            if (mergedCalendarShown) { return; }
            selectedItem = e.Item;
            if (selectedItem.Selected) {              
                eventDetailsPanel.Show();
                priorityBox.Hide();
                // Display Selected Event Details
                detailsEventName.Text = selectedItem.Text;
                datePickerStart.Value = selectedItem.StartDate.Date;
                timePickerStart.Value = selectedItem.StartDate.Date + selectedItem.StartDate.TimeOfDay;
                datePickerEnd.Value = selectedItem.EndDate.Date;
                timePickerEnd.Value = selectedItem.EndDate.Date + selectedItem.EndDate.TimeOfDay;
                modifyEventPriority.Value = selectedItem.priority;

                if (!isAdmin) {
                    detailsEventName.ReadOnly = true;
                    datePickerStart.Enabled = false;
                    timePickerStart.Enabled = false;
                    datePickerEnd.Enabled = false;
                    timePickerEnd.Enabled = false;
                    modifyEventPriority.Enabled = false;
                    ModifyEventBut.Enabled = false;
                    DeleteEventBut.Enabled = false;
                }
                else {
                    detailsEventName.ReadOnly = true;
                    datePickerStart.Enabled = true;
                    timePickerStart.Enabled = true;
                    datePickerEnd.Enabled = true;
                    timePickerEnd.Enabled = true;
                    modifyEventPriority.Enabled = true;
                    ModifyEventBut.Enabled = true;
                    DeleteEventBut.Enabled = true;
                }             
            }
            else {
                AddEvent addEventWindow = new AddEvent(this, e.Item.StartDate, e.Item.EndDate);
                calendar.Items.Remove(e.Item);
                addEventWindow.Show();
            }
        }

        /// <summary>
        /// Hide the details of an event
        /// </summary>
		private void eventDetailsBackBut_Click(object sender, EventArgs e)
		{
            eventDetailsPanel.Hide();
		}

        /// <summary>
        /// Cancels the team event for every team member
        /// </summary>
		private void DeleteEventBut_Click(object sender, EventArgs e)
		{
            //Confirm that the user wnats to delete the event.
            var result = MessageBox.Show("Are you sure you would like to delete this event from your schedule?",
                "Delete Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed delete event
            if (result == DialogResult.Yes)
            {
                Client.Client.Instance.CancelTeamEvent(selectedItem.eventID);
                eventDetailsPanel.Hide();
                _items.Remove(selectedItem);
                calendar.Items.Remove(selectedItem);
            }
        }

        /// <summary>
        /// Modifies the team event for every team member
        /// </summary>
		private void ModifyEventBut_Click(object sender, EventArgs e)
		{
            //Confirm that the user wnats to delete the event.
            var result = MessageBox.Show("Are you sure you would like to save the changes to this event?",
                "Modify Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed modify event
            if (result == DialogResult.Yes) 
            { 
                DateTime startDate = datePickerStart.Value.Date + timePickerStart.Value.TimeOfDay;
                DateTime endDate = datePickerEnd.Value.Date + timePickerEnd.Value.TimeOfDay;
                Event updatedEvent = new Event(selectedItem.eventID, modifyEventPriority.Value, Client.Client.Instance.username , detailsEventName.Text, startDate, endDate, selectedItem.teamEvent);
                _items.Remove(selectedItem);
                calendar.Items.Remove(selectedItem);
                displayEvent(updatedEvent);
                Client.Client.Instance.ModifyTeamEvent(updatedEvent, team.teamID);
            }
        }
    }
}
