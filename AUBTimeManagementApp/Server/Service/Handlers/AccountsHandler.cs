using AUBTimeManagementApp.Service.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Service.Handlers
{
    public class AccountsHandler: IAccountsHandler
    {
        public AccountsHandler()
        {

        }
        public int ConfirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth) {
            int checkPass = CheckPassword(password, confirmPassword);
            if(checkPass != 1) { return checkPass; }

            int checkReg = AccountsStorage.validateRegistration(username, email);
            if(checkReg != 1) { return -2 + checkReg; }

            bool ok = AccountsStorage.createAccount(username, firstName, lastName, email, password, dateOfBirth);
            return (ok ? 1 : -5);
        }

        public bool ConfirmLogIn(string username, string password) {
            return AccountsStorage.validateLogIn(username, password);
        }

        public bool LogOut() {
            return false;
        }

        public int ChangePassword(string username, string oldPassword, string newPassword, string confirmPassowrd) {

            int checkPass = CheckPassword(newPassword, confirmPassowrd);
            if(checkPass == -1) { return -1; }
            if(checkPass == -2) { return -2; }

            //
            //UPDATE THE PASSWORD
            //
            UpdatePassword(username, newPassword);

            return 1;
        }
        public bool IsRegistered(string username)
        {
            return AccountsStorage.usernameExists(username);
        }

        /// <summary>
        /// Checks if the password entered is valid
        /// 
        /// <para> The password should contain at least:</para>
        /// <list type="bullet">
        /// <item> 8 characters </item>
        /// <item> 1 LowerCase english letter</item>
        /// <item> 1 UpperCase english letter</item>
        /// <item> 1 Digit </item>
        /// <item> 1 non Alpha-Numeric character</item>
        /// </list>
        /// </summary>
        /// 
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns>
        /// <list type="bullet">
        /// <item> -1 if confirm password doesn't match password </item>
        /// <item> -2 if the password doesn't follow the rules above </item>
        /// <item> 1 if verification if successful </item>
        /// </list>
        /// </returns>
        private int CheckPassword(string password, string confirmPassword)
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

        private void UpdatePassword(string username, string newPassword)
        {
            AccountsStorage.updatePassword(username, newPassword);
        }
    }
}
