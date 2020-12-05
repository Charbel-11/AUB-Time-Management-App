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
            monthView.SelectionStart = monthView.SelectionEnd = DateTime.Today;
            mergedCalendarShown = merged;
            if (merged) { mergedSchedButton_Click(null, null); }
            else { priorityBoxBackButton_Click(null, null); }
            teamSchedButton_Click(null, null);
            eventDetailsPanel.Hide();
        }

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

        private void addEvent_Click(object sender, EventArgs e) {
            if (addEventForm != null && addEventForm.Visible) {
                addEventForm.Focus();
                return;
            }
            addEventForm = new AddEvent(this);
            addEventForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e) {
            TeamDetailsForm newForm = new TeamDetailsForm(team);
            newForm.Show(); Close();
        }

        public void displayColorFreq(double [,] freq) {
            int n = freq.GetLength(0), m = freq.GetLength(1);
            int R = 255;

            DateTime start = monthView.SelectionStart, end = monthView.SelectionEnd; //Maybe take those from the server
            calendar.Items.Clear(); _items.Clear();
            for (int i = 0; i < n; i++) {
                int firstJ = 0;
                while (firstJ < m) {
                    int j = firstJ;
                    while (j < m - 1 &&  freq[i, j] == freq[i, j + 1]) { j++; }
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

        public void displayEvent(Event _event) {
            CalendarItem curEvent = new CalendarItem(calendar, _event.startTime, _event.endTime, _event.eventName, _event.ID, _event.priority, _event.teamEvent);
            calendar.Items.Add(curEvent);
            _items.Add(curEvent);
        }

        private void teamSchedButton_Click(object sender, EventArgs e) {
            mergedCalendarShown = false;
            calendar.Items.Clear(); _items.Clear();
            Client.Client.Instance.GetTeamSchedule(team.teamID);
        }

        private void mergedSchedButton_Click(object sender, EventArgs e) {
            priorityBox.Show();
            addEventButton.Hide();
            teamSchedButton.Hide();
            mergedSchedButton.Hide();
            backButton.Hide();
        }

        private void priorityBoxBackButton_Click(object sender, EventArgs e) {
            addEventButton.Show();
            teamSchedButton.Show();
            mergedSchedButton.Show();
            backButton.Show();
            priorityBox.Hide();
        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            mergedCalendarShown = true;
            DateTime start = monthView.SelectionStart, end = monthView.SelectionEnd;
            if (end.Subtract(start).Days > 6) {
                end = start.AddDays(7);
                monthView.SelectionEnd = end;
            }
            Client.Client.Instance.GetMergedTeamSchedule(team.teamID, start, end, ModifyPriority.Value);
            priorityBoxBackButton_Click(null, null);
        }

        private void calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e) {
            selectedItem = e.Item;
            if (selectedItem.Selected) {
               
                eventDetailsPanel.Show();
                priorityBox.Hide();
                // Display Selected Event Details
                detailsEventName.Text = selectedItem.Text;
                dateTimePickerStart.Value = selectedItem.StartDate;
                dateTimePickerEnd.Value = selectedItem.EndDate;
                ModifyPriority.Value = selectedItem.priority;

                if (!isAdmin) {
                    detailsEventName.ReadOnly = true;
                    dateTimePickerStart.Enabled = false;
                    dateTimePickerEnd.Enabled = false;
                    ModifyPriority.Enabled = false;
                    ModifyEventBut.Enabled = false;
                    DeleteEventBut.Enabled = false;
                }
                
                
            }
            else {
                AddEvent addEventWindow = new AddEvent(this, e.Item.StartDate, e.Item.EndDate);
                calendar.Items.Remove(e.Item);
                addEventWindow.Show();
            }
        }

		private void eventDetailsBackBut_Click(object sender, EventArgs e)
		{
            eventDetailsPanel.Hide();
		}

		private void DeleteEventBut_Click(object sender, EventArgs e)
		{
            //Confirm that the user wnats to delete the event.
            var result = MessageBox.Show("Are you sure you would like to delete this event from your schedule?",
                "Delete Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed delete event
            if (result == DialogResult.Yes)
            {
                Client.Client.Instance.CancelTeamEvent(team.teamID, selectedItem.eventID);
                eventDetailsPanel.Hide();
                _items.Remove(selectedItem);
                calendar.Items.Remove(selectedItem);
            }
        }

		private void ModifyEventBut_Click(object sender, EventArgs e)
		{

		}
	}
}
