using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Accounts
{
    class AccountsHandler
    {
        public static int confirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth) {
            bool usernameTaken = false;
            //
            //CHECK THAT USERNAME IS NOT TAKEN
            //
            if (usernameTaken) { return -3; }

            int checkPass = checkPassword(password, confirmPassword);
            if(checkPass == -1) { return -1; }
            if(checkPass == -2) { return -2; }


            return 1;
        }

        public static bool logIn(string username, string password) {
            //
            //CHECK THAT USERNAME/OLDPASSWORD ARE VALID
            //

            //
            //CONNECT THE USER TO THE SERVER
            //
            return false;
        }

        public static bool logOut() {
            return false;
        }

        public static int changePassword(string username, string oldPassword, string newPassword, string confirmPassowrd) {

            int checkPass = checkPassword(newPassword, confirmPassowrd);
            if(checkPass == -1) { return -1; }
            if(checkPass == -2) { return -2; }

            //
            //UPDATE THE PASSWORD
            //

            return 1;
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
