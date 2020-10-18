using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.AUBTimeManagementApp.Service.Accounts
{
    class AccountsHandler
    {
        public static bool confirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth) {
            return false;
        }

        public static bool logIn(string username, string password) {
            return false;
        }

        public static bool logOut() {
            return false;
        }

        public static bool changePassword(string username, string oldPassword, string newPassword, string confirmPassowrd) {
            return false;
        }

        private static int checkPassword(string password, string confirmPassword)
        {
            if(password != confirmPassword) { return -1; }
            if(password.Length < 8) { return -2; }
            bool upper = false, lower = false, other = false, digit = false;

            foreach(char cur in password)
            {
                if (Char.IsUpper(cur)) { upper = true; continue; }
                if (Char.IsLower(cur)) { lower = true; continue; }
                if (Char.IsDigit(cur)) { digit = true; continue; }
                other = true;
            }

            if (upper && lower && digit && other) return 1;
            return -2;
        }
    }
}
