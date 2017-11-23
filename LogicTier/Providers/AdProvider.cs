using System;
using System.Collections.Generic;
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

        public Ad AddAd(Ad ad)
        {
            return _dataService.AddAd(ad);
        }

        public Ad GetAd(int id)
        {
            return _dataService.GetAd(id);
        }

        public IEnumerable<Ad> GetAds()
        {
            return _dataService.GetAds();
        }
    }
}
