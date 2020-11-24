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
        public mainForm(string username = null) {
            Client.Client.Instance.setForm(this);
            _username = username;
            InitializeComponent();
            label1.Text = "Welcome " + username + "!";
            label1.Show();
            filteringPanel.Hide();
            eventDetailsPanel.Hide();
        }

        public void displayTeam(string newTeam, string newMembers) {
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
                string nameAndPriority = selectedItem.Text;
                detailsEventName.Text = nameAndPriority.Remove(nameAndPriority.Length - 1, 1);
                detailsStartTime.Text = selectedItem.StartDate.ToString();
                detailsEndTime.Text = selectedItem.EndDate.ToString();
                string priority;
                if(nameAndPriority[nameAndPriority.Length - 1] == '1')
				{
                    priority = "Low";
				}
                else if(nameAndPriority[nameAndPriority.Length - 1] == '2')
				{
                    priority = "Medium";
				}
				else
				{
                    priority = "High";
                }
                detailsPriority.Text = priority;
                //detailsPriority.Text = selectedItem.eventID.ToString();
                selectedItemID = selectedItem.eventID;
			}
            //Else:
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
               Client.Client.Instance.CancelPersonalEvent(selectedItemID);
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
                "Delete Event", MessageBoxButtons.YesNo);
            //If the yes button is pressed delete event
            if (result == DialogResult.Yes)
            {
                //get text from text boxes and make event
                //Client.Client.Instance.ModifyPersonalEvent(updatedEvent);
            }
        }

		private void detailsStartTime_TextChanged(object sender, EventArgs e)
		{

		}

        private void Refresh_Click(object sender, EventArgs e)
        {
            _items.Clear();
            calendar.Items.Clear();
            Client.Client.Instance.GetUserSchedule();
        }

        public void updateEventID(int eventID)
		{
            CalendarItem addedItem = _items[_items.Count() - 1];
            addedItem.eventID = eventID;
            
		}
    }
}