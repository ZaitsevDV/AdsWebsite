using AW.Common.Models;
using AW.Data.Business;
using AW.Data.Clients;
using System.Collections.Generic;

namespace AW.Data.Repositories
{
    public class UserService : IUserService
    {
        private readonly IClient _client;
        private readonly IConvert _convert;

        public UserService(IClient client, IConvert convert)
        {
            _client = client;
            _convert = convert;
        }

        public List<User> GetUsers()
        {
            var usersDto = _client.GetUsersDto();
            if (usersDto == null) return default(List<User>);
            return _convert.ToUsers(usersDto) as List<User>;
        }

        public void CreateUser(User user)
        {
            var userDto = _convert.ToUserDto(user);
            _client.CreateUserDto(userDto);
        }

        public void EditeUser(User user)
        {
            var userDto = _convert.ToUserDto(user);
            _client.EditeUserDto(userDto);
        }

        public void EditePassword(string userName, string password)
        {
            _client.EditePasswordDto(userName, password);
        }

        public void DeleteUser(string userName)
        {
            _client.DeleteUserDto(userName);
        }

        public User GetUserByName(string userName)
        {
            var userDto = _client.GetUserDtoByName(userName);
            if (userDto == null) return default(User);
            return _convert.ToUser(userDto);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _client.IsValidUser(userName, password);
        }

        public List<Phone> GetPhones(string userName)
        {
            var phonesDto = _client.GetPhonesDto(userName);
            if (phonesDto == null) return default(List<Phone>);
            return _convert.ToPhones(phonesDto);
        }

        public void CreatePhone(Phone phone)
        {
            var phoneDto = _convert.ToPhoneDto(phone);
            _client.CreatePhoneDto(phoneDto);
        }

        public void EditePhone(Phone phone)
        {
            var phoneDto = _convert.ToPhoneDto(phone);
            _client.EditePhoneDto(phoneDto);
        }

        public void DeletePhone(int phoneId)
        {
            _client.DeletePhoneDto(phoneId);
        }

        public List<Email> GetEmails(string userName)
        {
            var emailDto = _client.GetEmailsDto(userName);
            if (emailDto == null) return default(List<Email>);
            return _convert.ToEmails(emailDto);
        }

        public void CreateEmail(Email email)
        {
            var emailDto = _convert.ToEmailDto(email);
            _client.CreateEmailDto(emailDto);
        }

        public void EditeEmail(Email email)
        {
            var emailDto = _convert.ToEmailDto(email);
            _client.EditeEmailDto(emailDto);
        }

        public void DeleteEmail(int emailId)
        {
            _client.DeleteEmailDto(emailId);
        }

        public List<Role> GetRoles()
        {
            var rolesDto = _client.GetRolesDto();
            if (rolesDto == null) return default(List<Role>);
            return _convert.ToRoles(rolesDto);
        }
    }
}