using AW.Common.Models;
using System.Collections.Generic;

namespace AW.Data.Repositories
{
    public interface IUserService
    {
        List<User> GetUsers();
        void CreateUser(User user);
        void EditeUser(User user);
        void EditePassword(string userName, string password);
        void DeleteUser(string userName);
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        List<Role> GetRoles();
        List<Phone> GetPhones(string userName);
        void CreatePhone(Phone phone);
        void EditePhone(Phone phone);
        void DeletePhone(int phoneId);
        List<Email> GetEmails(string userName);
        void CreateEmail(Email email);
        void EditeEmail(Email email);
        void DeleteEmail(int emailId);
    }
}