using Common.Models;
using DataTier.AdService;
using DataTier.Business;
using DataTier.Clients;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public class DataService : IDataService
    {
        private readonly IClient _client;
        private readonly IConvert _convert;

        public DataService(IClient client, IConvert convert)
        {
            _client = client;
            _convert = convert;
        }

        public Ad GetAdDetails(int id)
        {
            var adDto = _client.GetAdDetailsDto(id);
            if (adDto == null) return default(Ad);
            return _convert.ToAd(adDto);
        }

        public IEnumerable<Ad> GetAds()
        {
            var adsDto = _client.GetAdsDto();
            if (adsDto == null) return default(List<Ad>);
            var ads = (IList<AdDto>) adsDto;
            return _convert.ToAds(ads) as List<Ad>;
        }

        public List<Category> GetCategories()
        {
            var categoriesDto = _client.GetCategoriesDto();
            if (categoriesDto == null) return default(List<Category>);
            var categories = (List<CategoryDto>) categoriesDto;
            return _convert.ToCategories(categories) as List<Category>;
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
    }
}