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
    public partial class SignInUpForm : Form
    {
        private string username;
        public SignInUpForm()
        {
            Client.Client.Instance.setForm(this);

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e) {
            username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            Client.Client.Instance.logIn(username, password);
        }
        public void loginReply(bool OK) { 
            if (OK)
            {
                Client.Client.Instance.GetUserSchedule();
                mainForm form1 = new mainForm(username);
                form1.Show();
                Close();
            }
            else
            {

            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(this);
            registrationForm.Show();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
