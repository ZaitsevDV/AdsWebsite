using Common.Models;
using DataTier.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class AdsService : IAdsService
    {
        private readonly IAdsRepository _adsRepository;

        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public async Task<Ad> AddAdAsync(Ad ad)
        {
            return await _adsRepository.AddAdAsync(ad);
        }

        public async Task<IEnumerable<Ad>> GetAdsAsync()
        {
            return await _adsRepository.GetAdsAsync();
        }

        public async Task<Ad> GetAdAsync(int id)
        {
            return await _adsRepository.GetAdAsync(id);
        }

        public async Task<Ad> UpdateAdAsync(Ad ad)
        {
            return await _adsRepository.UpdateAdAsync(ad);
        }

        public async Task DeleteAdAsync(int id)
        {
            await _adsRepository.DeleteAdAsync(id);
        }
    }
}