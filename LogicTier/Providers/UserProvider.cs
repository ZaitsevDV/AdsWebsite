using Common.Models;
using DataTier.Repositories;
using System;
using System.Collections.Generic;

namespace LogicTier.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService _dataService;

        public UserProvider(IUserService dataService)
        {
            _dataService = dataService ?? throw new NullReferenceException();
        }


        public IEnumerable<User> GetUsers()
        {
            return _dataService.GetUsers();
        }

        public User GetUserByName(string userName)
        {
            return _dataService.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _dataService.IsValidUser(userName, password);
        }
    }
}
