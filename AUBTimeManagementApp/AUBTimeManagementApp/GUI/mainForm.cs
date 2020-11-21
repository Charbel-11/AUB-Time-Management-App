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
        public mainForm(string username = null) {
            Client.Client.Instance.setForm(this);

            InitializeComponent();
            label1.Text = "Welcome " + username + "!";
            label1.Show();
            filteringPanel.Hide();
            eventDetailsPanel.Hide();
        }

        public void displayTeam(string newTeam, string newMembers) {
        }

        public void displayEvent(string eventName, int priority, DateTime startDate, DateTime endDate) {
            CalendarItem curEvent = new CalendarItem(calendar, startDate, endDate, eventName + " " + priority);
            calendar.Items.Add(curEvent);
            _items.Add(curEvent);
        }


        private void TeamButton_Click(object sender, EventArgs e) {
            TeamsForm addTeamWindow = new TeamsForm();
            addTeamWindow.Show();
            Close();
        }

        private void addEvent_MouseClick(object sender, MouseEventArgs e) {
            AddEvent addEventWindow = new AddEvent(this);
            addEventWindow.Show();
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
            CalendarItem selectedItem = e.Item;
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}


		private void eventDetailsBackBut_Click(object sender, EventArgs e)
		{
            eventDetailsPanel.Hide();
            mainPanel.Show();
		}

		private void detailsEndTime_TextChanged(object sender, EventArgs e)
		{

		}

		private void DeleteEventBut_Click(object sender, EventArgs e)
		{
            
		}

		private void ModifyEventBut_Click(object sender, EventArgs e)
		{

		}
	}
}