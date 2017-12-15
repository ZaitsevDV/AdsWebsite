using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Business.Providers
{
    public interface IUserProvider
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
    }
}