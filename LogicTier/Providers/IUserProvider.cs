using Common.Models;
using System.Collections.Generic;

namespace LogicTier.Providers
{
    public interface IUserProvider
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
    }
}
