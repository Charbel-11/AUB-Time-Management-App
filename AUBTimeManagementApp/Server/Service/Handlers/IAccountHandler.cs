using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    public interface IAccountsHandler
    {
        // This function checks whether the registration info were valid to register the user
        int ConfirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth);
        
        // This function checks if the username and password are correct
        bool ConfirmLogIn(string username, string password);

        // This function updates the password
        int ChangePassword(string username, string oldPassword, string newPassword, string confirmPassowrd);
        
        // This function checks whether there exists a user with a given username
        bool IsRegistered(string username);
    }
}
