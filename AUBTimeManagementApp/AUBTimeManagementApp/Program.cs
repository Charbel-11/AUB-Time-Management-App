using System;
using System.Windows.Forms;
using AUBTimeManagementApp.GUI;
using AUBTimeManagementApp.Client;

namespace AUBTimeManagementApplication
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Client.Instance.initializeSocket();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SignInUpForm curForm = new SignInUpForm();
            curForm.Show();

            Application.Run();
        }
    }
}
