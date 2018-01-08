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

        public List<User> GetUsers()
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

        public void CreateUser(User user)
        {
            _dataService.CreateUser(user);
        }

        public void EditeUser(User user)
        {
            _dataService.EditeUser(user);
        }

        public void EditePassword(string userName, string password)
        {
            _dataService.EditePassword(userName, password);
        }

        public void DeleteUser(string userName)
        {
            _dataService.DeleteUser(userName);
        }

        public List<Phone> GetPhones(string userName)
        {
            return _dataService.GetPhones(userName);
        }

        public void CreatePhone(Phone phone)
        {
            _dataService.CreatePhone(phone);
        }

        public void EditePhone(Phone phone)
        {
            _dataService.EditePhone(phone);
        }

        public void DeletePhone(int phoneId)
        {
            _dataService.DeletePhone(phoneId);
        }

        public List<Email> GetEmails(string userName)
        {
            return _dataService.GetEmails(userName);
        }

        public void CreateEmail(Email email)
        {
            _dataService.CreateEmail(email);
        }

        public void EditeEmail(Email email)
        {
            _dataService.EditeEmail(email);
        }

        public void DeleteEmail(int emailId)
        {
            _dataService.DeleteEmail(emailId);
        }

        public List<Role> GetRoles => _dataService.GetRoles();
    }
}