using AW.Common.Models;
using AW.Data.Repositories;
using System;
using System.Collections.Generic;

namespace AW.Business.Providers
{
    public class AdProvider : IAdProvider
    {
        private readonly IAdService _dataService;

        public AdProvider(IAdService dataService)
        {
            _dataService = dataService ?? throw new NullReferenceException();
        }

        public void CreateAd(Ad ad)
        {
            _dataService.CreateAd(ad);
        }

        public void EditeAd(Ad ad)
        {
            _dataService.EditeAd(ad);
        }

        public void DeleteAd(int adId)
        {
            _dataService.DeleteAd(adId);
        }

        public AdDetails GetAdDetails(int id)
        {
            return _dataService.GetAdDetails(id);
        }

        public List<Ad> GetAds => _dataService.GetAds();

        public List<Ad> GetAdsByCategory(int categoryId)
        {
            return _dataService.GetAdsByCategory(categoryId);
        }

        public List<Category> GetCategories => _dataService.GetCategories();

        public List<Condition> GetConditions => _dataService.GetConditions();

        public List<Location> GetLocations => _dataService.GetLocations();

        public List<AdType> GetTypes => _dataService.GetTypes();
    }
}