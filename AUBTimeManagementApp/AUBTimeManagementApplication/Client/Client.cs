using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.DataContracts;
using AUBTimeManagementApp.Service;

namespace AUBTimeManagementApp.Client
{
    class Client
    {
        public string username;
        private Schedule schedule;
        private Team[] teams;

        public void CreateAccount(string username, string password, string email)
        {
            if(username == "Charbel") { return; }
            
            //TODO
            this.username = username;
        }

        public void LogIn(string username, string password)
        {
            //TODO
            this.username = username;
        }

        public void LogOut()
        {

        }

        public void ChangePassword(string oldPassword, string oldPasswordCheck, string newPassword)
        {

        }
    }
}
