using Common.Models;
using DataTier.Business;
using DataTier.Clients;
using DataTier.DataService;
using System.Collections.Generic;

namespace DataTier.Repositories
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
            var users = (IList<UserDto>)usersDto;
            return _convert.ToUsers(users) as List<User>;
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
    }
}
