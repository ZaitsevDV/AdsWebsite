using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using DataTier.Repositories;

namespace LogicTier.Providers
{
    public class AdProvider : IAdProvider
    {
        private readonly IDataService _dataService;

        public AdProvider(IDataService dataService)
        {
            _dataService = dataService ?? throw new NullReferenceException();
        }

        public Ad GetAdDetails(int id)
        {
            return _dataService.GetAdDetails(id);
        }

        public IEnumerable<Ad> GetAds => _dataService.GetAds();

        public IEnumerable<User> GetUsers => _dataService.GetUsers();

        public IEnumerable<Category> GetCategories
        {
            get { return _dataService.GetCategories().OrderBy(x => x.CategoryName); }
        }

    }
}
