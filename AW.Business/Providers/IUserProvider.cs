using AW.Common.Models;
using System.Collections.Generic;

namespace AW.Business.Providers
{
    public interface IUserProvider
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        List<Email> GetEmails { get; }
        List<Phone> GetPhones { get; }
        List<Role> GetRoles { get; }
    }
}