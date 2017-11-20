using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace LogicTier.Providers
{
    public interface IAdProvider
    {
        Task<IEnumerable<Ad>> GetAdsAsync();
        Task<Ad> AddAdAsync(Ad ad);
    }
}
