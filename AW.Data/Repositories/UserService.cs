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


        public IEnumerable<User> GetUsers()
        {
            var usersDto = _client.GetUsersDto();
            if (usersDto == null) return default(List<User>);
            return _convert.ToUsers(usersDto) as List<User>;
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

        public List<Email> GetEmails()
        {
            var emailDto = _client.GetEmailsDto();
            if (emailDto == null) return default(List<Email>);
            return _convert.ToEmails(emailDto);
        }

        public List<Phone> GetPhones()
        {
            var phonesDto = _client.GetPhonesDto();
            if (phonesDto == null) return default(List<Phone>);
            return _convert.ToPhones(phonesDto);
        }

        public List<Role> GetRoles()
        {
            var rolesDto = _client.GetRolesDto();
            if (rolesDto == null) return default(List<Role>);
            return _convert.ToRoles(rolesDto);
        }
    }
}