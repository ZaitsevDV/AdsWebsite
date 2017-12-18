using AW.Common.Models;
using AW.Data.Repositories;
using System;
using System.Collections.Generic;

namespace AW.Business.Providers
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

        public List<Email> GetEmails => _dataService.GetEmails();

        public List<Phone> GetPhones => _dataService.GetPhones();

        public List<Role> GetRoles => _dataService.GetRoles();
    }
}