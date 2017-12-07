using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
    }
}
