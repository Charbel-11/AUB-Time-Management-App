using System;
using System.Collections.Generic;
using System.Text;
using AUBTimeManagementApp.AUBTimeManagementApp.DataContracts;
using AUBTimeManagementApp.AUBTimeManagementApp.Service;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Client
{
    class Client
    {
        public string username;
        private Schedule schedule;
        private Team[] teams;

        void CreateAccount(string username, string password, string email)
        {
            if(username == "Charbel"){return;}
            //TODO
            this.username = username;
        }

        void LogIn(string username, string password)
        {
            //TODO
            this.username = username;
        }

        void LogOut()
        {

        }

        void ChangePassword(string oldPassword, string oldPasswordCheck, string newPassword)
        {

        }
    }
}
