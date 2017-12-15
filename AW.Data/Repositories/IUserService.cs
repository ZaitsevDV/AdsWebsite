using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Data.Repositories
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
    }
}