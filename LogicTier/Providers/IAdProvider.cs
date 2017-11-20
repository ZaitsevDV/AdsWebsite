using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace LogicTier.Providers
{
    public interface IAdProvider
    {
        Ad AddAd(Ad ad);
        IEnumerable<Ad> GetAds();
    }
}
