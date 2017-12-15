using System.Collections.Generic;
using AW.Common.Models;
using AW.Data.Business;
using AW.Data.Clients;
using AW.Data.DataService;

namespace AW.Data.Repositories
{
    public class AdService : IAdService
    {
        private readonly IClient _client;
        private readonly IConvert _convert;

        public AdService(IClient client, IConvert convert)
        {
            _client = client;
            _convert = convert;
        }

        public List<Ad> GetAdsByCategory(int categoryId)
        {
            var adsDto = _client.GetAdsByCategoryDto(categoryId);
            if (adsDto == null) return default(List<Ad>);
            var ads = (IList<AdDto>) adsDto;
            return _convert.ToAds(ads) as List<Ad>;
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
            var categories = categoriesDto;
            return _convert.ToCategories(categories);
        }
    }
}