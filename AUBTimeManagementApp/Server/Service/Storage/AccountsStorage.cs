using System;
using System.Collections.Generic;
using System.Text;

namespace AUBTimeManagementApp.Service.Storage
{
    class AccountsStorage {

        public static bool usernameExists(string username) {
            return true;
        }

        public static int validateRegistration(string username, string email) {
            return 1;
        }

        public static bool validateLogIn(string username, string password) {
            return true;
        }

        public static bool validateChangePassword(string username, string password) {
            return true;
        }

        public static bool updatePassword(string username, string password) {
            return true;
        }

        public static bool createAccount(string username, string firstName, string lastName, string email, string password, DateTime dateOfBirth) {
            return true;
        }

        public static int[] getUserTeams(string username) {
            int[] teams = new int[0]; 
            return teams;
        }

    }
}
