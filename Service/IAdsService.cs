using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IAdsService
    {
        Task<Ad> GetAdAsync(int id);
        Task<Ad> AddAdAsync(Ad ad);
        Task<IEnumerable<Ad>> GetAdsAsync();
        Task DeleteAdAsync(int id);
        Task<Ad> UpdateAdAsync(Ad ad);
    }
}
