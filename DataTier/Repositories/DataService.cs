using Common.Models;
using System.Collections.Generic;
using DataTier.AdService;
using DataTier.Business;
using DataTier.Clients;

namespace DataTier.Repositories
{
    public class DataService : IDataService
    {
        private readonly IAdClient _adClient;
        private readonly IConvert _convert;

        public DataService(IAdClient client, IConvert convert)
        {
            _adClient = client;
            _convert = convert;
        }

        public Ad GetAdDetails(int id)
        {
            var adDto = _adClient.GetAdDetailsDto(id);
            return adDto != null ? _convert.ToAd(adDto) : default(Ad);
        }

        public IEnumerable<Ad> GetAds()
        {
            var adsDto = _adClient.GetAdsDto();
            if (adsDto == null) return default(List<Ad>);
            var ads = (IList<AdDto>) adsDto;
            return _convert.ToAds(ads) as List<Ad>;
        }

        public List<Category> GetCategories()
        {
            var categoriesDto = _adClient.GetCategoriesDto();
            if (categoriesDto == null) return default(List<Category>);
            var categories = (List<CategoryDto>) categoriesDto;
            return _convert.ToCategories(categories) as List<Category>;
        }

        public IEnumerable<User> GetUsers()
        {
            var usersDto = _adClient.GetUsersDto();
            if (usersDto == null) return default(List<User>);
            var users = (IList<UserDto>)usersDto;
            return _convert.ToUsers(users) as List<User>;
        }
    }
}