using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace LogicTier.Providers
{
    public class AdProvider : IAdProvider
    {
        private readonly IAdsService _adsService;

        public AdProvider(IAdsService adsService)
        {
            _adsService = adsService ?? throw new NullReferenceException();
        }

        public async Task<Ad> AddAdAsync(Ad ad)
        {
            return await _adsService.AddAdAsync(ad);
        }

        public async Task<IEnumerable<Ad>> GetAdsAsync()
        {
            return await _adsService.GetAdsAsync();
        }
    }
}
