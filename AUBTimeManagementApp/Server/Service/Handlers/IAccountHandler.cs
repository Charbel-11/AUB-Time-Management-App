using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    public interface IAccountsHandler
    {
        int ConfirmRegistration(string username, string firstName, string lastName, string email, string password, string confirmPassword, DateTime dateOfBirth);
        bool ConfirmLogIn(string username, string password);
        bool LogOut();
        int ChangePassword(string username, string oldPassword, string newPassword, string confirmPassowrd);
    }
}
