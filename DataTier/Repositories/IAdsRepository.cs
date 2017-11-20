using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataTier.Repositories
{
    public interface IAdsRepository
    {
        Task<Ad> GetAdAsync(int id);
        Task<Ad> AddAdAsync(Ad ad);
        Task<IEnumerable<Ad>> GetAdsAsync();
        Task DeleteAdAsync(int id);
        Task<Ad> UpdateAdAsync(Ad ad);
    }
}
