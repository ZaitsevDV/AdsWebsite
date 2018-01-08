using AW.Common.Models;
using AW.Data.Business;
using AW.Data.Clients;
using System.Collections.Generic;

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

        public void CreateAd(Ad ad)
        {
            var adDto = _convert.ToAdDto(ad);
            _client.CreateAdDto(adDto);
        }

        public void EditeAd(Ad ad)
        {
            var adDto = _convert.ToAdDto(ad);
            _client.EditeAdDto(adDto);
        }

        public void DeleteAd(int adId)
        {
            _client.DeleteAdDto(adId);
        }

        public List<Ad> GetAdsByCategory(int categoryId)
        {
            var adsDto = _client.GetAdsByCategoryDto(categoryId);
            if (adsDto == null) return default(List<Ad>);
            return _convert.ToAds(adsDto) as List<Ad>;
        }

        public AdDetails GetAdDetails(int id)
        {
            var adDetailsDto = _client.GetAdDetailsDto(id);
            if (adDetailsDto == null) return default(AdDetails);
            return _convert.ToAdDetails(adDetailsDto);
        }

        public List<Ad> GetAds()
        {
            var adsDto = _client.GetAdsDto();
            if (adsDto == null) return default(List<Ad>);
            return _convert.ToAds(adsDto) as List<Ad>;
        }

        public List<Category> GetCategories()
        {
            var categoriesDto = _client.GetCategoriesDto();
            if (categoriesDto == null) return default(List<Category>);
            return _convert.ToCategories(categoriesDto);
        }

        public List<Condition> GetConditions()
        {
            var conditions = _client.GetConditionsDto();
            if (conditions == null) return default(List<Condition>);
            return _convert.ToConditions(conditions);
        }

        public List<Location> GetLocations()
        {
            var locations = _client.GetLocationsDto();
            if (locations == null) return default(List<Location>);
            return _convert.ToLocations(locations);
        }

        public List<AdType> GetTypes()
        {
            var types = _client.GetTypesDto();
            if (types == null) return default(List<AdType>);
            return _convert.ToTypes(types);
        }
    }
}