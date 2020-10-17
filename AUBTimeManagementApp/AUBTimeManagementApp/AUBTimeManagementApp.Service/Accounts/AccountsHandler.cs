using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Service.Accounts
{
    class AccountsHandler
    {
        static bool confirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth) {
            return false;
        }

        static bool logIn(string username, string password) {
            return false;
        }

        static bool logOut() {
            return false;
        }

        static bool changePassword(string username, string oldPassword, string newPassword, string confirmPassowrd) {
            return false;
        }
    }
}
