using AW.Common.Models;
using System.Collections.Generic;

namespace AW.Data.Repositories
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        List<Email> GetEmails();
        List<Phone> GetPhones();
        List<Role> GetRoles();
    }
}