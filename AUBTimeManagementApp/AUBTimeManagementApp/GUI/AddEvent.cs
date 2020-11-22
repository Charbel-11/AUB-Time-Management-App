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
        mainForm parent;
        public AddEvent(mainForm _parent)
        {
            parent = _parent;
            Client.Client.Instance.setForm(this);

            InitializeComponent();
        }

        public AddEvent(mainForm _parent, DateTime _startDate, DateTime _endDate) : this(_parent) {
            startDate.Value = _startDate;
            endDate.Value = _endDate;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Client.Client.Instance.showEvent(eventName.Text, priority.Value, startDate.Value, endDate.Value);
            Client.Client.Instance.CreatePersonalEvent(eventName.Text, priority.Value, startDate.Value, endDate.Value);
            Close();
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
