using System;
using System.Collections.Generic;
using Common.Models;
using DataTier.Repositories;

namespace LogicTier.Providers
{
    public class AdProvider : IAdProvider
    {
        private readonly IAdsRepository _adsRepository;

        public AdProvider(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository ?? throw new NullReferenceException();
        }

        public Ad AddAd(Ad ad)
        {
            return _adsRepository.AddAd(ad);
        }

        public IEnumerable<Ad> GetAds()
        {
            return _adsRepository.GetAds();
        }
    }
}
