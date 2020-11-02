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
    public partial class RegistrationForm : Form
    {
        SignInUpForm parent;
        public RegistrationForm(SignInUpForm _parent)
        {
            parent = _parent;
            Client.Client.Instance.setForm(this);

            InitializeComponent();
        }

        public void registrationReply(int OK)
        {
            if (OK == -1) {
                return;
            }
            if (OK == -2) {
                return;
            }
            if (OK == -3) {
                return;
            }
            parent.Show();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;
            DateTime dateOfBirth = DateOfBirth.Value;

            Client.Client.Instance.createAccount(username, firstName, lastName, password, confirmPassword, email, dateOfBirth);
        }
    }
}
