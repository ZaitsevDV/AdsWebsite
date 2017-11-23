using Common.Models;
using System.Collections.Generic;

namespace LogicTier.Providers
{
    public interface IAdProvider
    {
        Ad AddAd(Ad ad);
        Ad GetAd(int id);
        IEnumerable<Ad> GetAds();
    }
}
