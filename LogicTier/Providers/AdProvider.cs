using Common.Models;
using DataTier.Repositories;
using System;
using System.Collections.Generic;

namespace LogicTier.Providers
{
    public class AdProvider : IAdProvider
    {
        private readonly IAdService _dataService;

        public AdProvider(IAdService dataService)
        {
            _dataService = dataService ?? throw new NullReferenceException();
        }

        public Ad GetAdDetails(int id)
        {
            return _dataService.GetAdDetails(id);
        }

        public IEnumerable<Ad> GetAds => _dataService.GetAds();

        public List<Ad> GetAdsByCategory(int categoryId)
        {
            return _dataService.GetAdsByCategory(categoryId);
        }

        public List<Category> GetCategories => _dataService.GetCategories();

    }
}
