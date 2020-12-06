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

        /// <summary>
        /// Displays the server's feedback
        /// </summary>
        /// <param name="OK">The state of the feedback</param>
        public void registrationReply(int OK)
        {
            if (OK == -1) {
                ErrorLabel.Text = "The confirmed password and the password are not identical!";
                return;
            }
            if (OK == -2) {
                ErrorLabel.Text = "The password does not follow the specified format!";
                return;
            }
            if (OK == -3) {
                ErrorLabel.Text = "Username already exists!";
                return;
            }
            if(OK == -4) {
                ErrorLabel.Text = "Email already exists!";
                return;
            }
            parent.Show();
            Close();
        }

        /// <summary>
        /// Sends a request to the server to register according to the user input
        /// </summary>
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

        /// <summary>
        /// Go back to the sign in/up panel
        /// </summary>
        private void GoBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
