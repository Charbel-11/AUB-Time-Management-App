using AUBTimeManagementApp.DataContracts;
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

namespace AUBTimeManagementApp.GUI
{
    public partial class mainForm : Form {
        List<CalendarItem> _items = new List<CalendarItem>();   //Maybe we should put this in the client code (took it from the demo)
        string _username;
        int selectedItemID;
        CalendarItem selectedItem;
        AddEvent addEventForm;
        InvitationsForm invitationsForm;
        public mainForm(string username = null) {
            Client.Client.Instance.setForm(this);
            _username = username;
            InitializeComponent();
            calendar.AllowItemEdit = false;
            calendar.AllowItemResize = false;
            label1.Text = "Welcome " + username + "!";
            label1.Show();
            filteringPanel.Hide();
            eventDetailsPanel.Hide();
        }

        public void displayEvent(int eventID, string eventName, int priority, DateTime startDate, DateTime endDate) {
            CalendarItem curEvent = new CalendarItem(calendar, startDate, endDate, eventName, eventID, priority);
            calendar.Items.Add(curEvent);
            _items.Add(curEvent);
        }


        private void TeamButton_Click(object sender, EventArgs e) {
            TeamsForm addTeamWindow = new TeamsForm();
            addTeamWindow.Show();
            Close();
        }

        private void addEvent_MouseClick(object sender, MouseEventArgs e) {
            if (addEventForm != null && addEventForm.Visible) {
                addEventForm.Focus();
                return;
            }
            addEventForm = new AddEvent(this);
            addEventForm.Show();
        }

        private void PlaceItems() {
            foreach (CalendarItem item in _items) {
                if (calendar.ViewIntersects(item)) {
                    calendar.Items.Add(item);
                }
            }
        }

        private void monthView_SelectionChanged(object sender, EventArgs e) {
            calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionEnd);
        }

        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e) {
            PlaceItems();
        }

        private void calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e) {
            //NOT SURE IT'S CORRECT
            //Check if event already exists at this time, if so open its description
            selectedItem = e.Item;
            if(selectedItem.Selected)
			{
                mainPanel.Hide();
                eventDetailsPanel.Show();
                detailsEventName.Text = selectedItem.Text;
                dateTimePickerStart.Value = selectedItem.StartDate;
                dateTimePickerEnd.Value = selectedItem.EndDate;
                //detailsEndTime.Text = selectedItem.EndDate.ToString();
               /* string priority;
                if(selectedItem.priority == 1)
				{
                    priority = "Low";
				}
                else if(selectedItem.priority == 2)
				{
                    priority = "Medium";
				}
				else
				{
                    priority = "High";
                }*/
                ModifyPriority.Value = selectedItem.priority;
                //detailsPriority.Text = selectedItem.eventID.ToString();
                selectedItemID = selectedItem.eventID;
			}
            else
            {
                AddEvent addEventWindow = new AddEvent(this, e.Item.StartDate, e.Item.EndDate);
                calendar.Items.Remove(e.Item);
                addEventWindow.Show();
            }
        }

        private void backButton_Click(object sender, EventArgs e) {
            Client.Client.Instance.logOut();
            SignInUpForm nF = new SignInUpForm();
            nF.Show();
            Close();
        }

		private void filterUserScheduleBut_Click(object sender, EventArgs e)
		{
            mainPanel.Hide();
            filteringPanel.Show();

        }

		private void filterBackBut_Click(object sender, EventArgs e)
		{
            filteringPanel.Hide();
            mainPanel.Show();
		}

		private void filterDoneButton_Click(object sender, EventArgs e)
		{
            filteringPanel.Hide();
            mainPanel.Show();
            _items.Clear();
            calendar.Items.Clear();
            Client.Client.Instance.FilterUserSchedule(Low.Checked, Medium.Checked, High.Checked );
        }

		private void eventDetailsBackBut_Click(object sender, EventArgs e)
		{
            eventDetailsPanel.Hide();
            mainPanel.Show();
		}

		private void DeleteEventBut_Click(object sender, EventArgs e)
		{
            //Confirm that the user wnats to delete the event.
            var result = MessageBox.Show("Are you sure you would like to delete this event from your schedule?",
                "Delete Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed delete event
            if (result == DialogResult.Yes)
            { 
               Client.Client.Instance.CancelUserEvent(selectedItemID);
               eventDetailsPanel.Hide();
                mainPanel.Show();
                _items.Remove(selectedItem);
                calendar.Items.Remove(selectedItem);
            }
        }
		private void ModifyEventBut_Click(object sender, EventArgs e)
		{
            //Confirm that the user wnats to delete the event.
            var result = MessageBox.Show("Are you sure you would like to save the changes to this event?",
                "Modify Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed delete event
            if (result == DialogResult.Yes)
            {
                Event updatedEvent = new Event(selectedItem.eventID,ModifyPriority.Value, _username, detailsEventName.Text, dateTimePickerStart.Value, dateTimePickerEnd.Value);
                _items.Remove(selectedItem);
                calendar.Items.Remove(selectedItem);
                _items.Add(new CalendarItem(calendar, updatedEvent.startTime, updatedEvent.endTime, updatedEvent.eventName, updatedEvent.ID, updatedEvent.priority));
                PlaceItems();
                Client.Client.Instance.ModifyUserEvent(updatedEvent);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            calendar.Items.Clear();
            _items.Clear();
            Client.Client.Instance.GetUserSchedule();
        }

        public void updateEventID(int eventID)
		{
            CalendarItem addedItem = _items[_items.Count() - 1];
            addedItem.eventID = eventID;
            
		}

        private void InvitationsButton_Click(object sender, EventArgs e)
        {
            if (invitationsForm != null && invitationsForm.Visible)
            {
                invitationsForm.Focus();
                return;
            }
            invitationsForm = new InvitationsForm(this);
            invitationsForm.Show();
        }

        // I passed an entire event object (not just a name) although I only used the name
        // because we might display event details in the warning message
        // simply because an event name is not a unique identifier of an event
        public void informUserAboutConflicts(Event _event, List<Event> conflictingEvents)
        {
            string warning = "Warning:\n Event " + _event.eventName + " is in conflict with the following events:\n";
            for (int i = 0; i < conflictingEvents.Count; i++)
            {
                warning += conflictingEvents[i].eventName;
                if (i != conflictingEvents.Count - 1)
                {
                    warning += " & ";
                }
            }

            MessageBox.Show(warning, "Conflict Warning!");
        }
    }
}