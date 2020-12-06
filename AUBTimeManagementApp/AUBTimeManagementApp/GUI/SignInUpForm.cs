using System;
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

        private void LoginButton_Click(object sender, EventArgs e) {
            username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            Client.Client.Instance.logIn(username, password);
        }
        public void loginReply(bool OK) { 
            if (OK)
            {
                if (Client.Client.Instance.mainForm != null && Client.Client.Instance.mainForm.Visible) { return; }
                Client.Client.Instance.GetUserSchedule();
                Client.Client.Instance.GetUserTeams();
                Client.Client.Instance.GetUserInvitations();
                mainForm form1 = new mainForm(username);
                form1.Show();
                Close();
            }
            else
            {
                ErrorLabel.Text = "Invalid Username/Password.";
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(this);
            registrationForm.Show();
        }
    }
}
