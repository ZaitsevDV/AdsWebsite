using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IAdsRepository
    {
        Ad GetAd(int id);
        Ad AddAd(Ad ad);
        IEnumerable<Ad> GetAds();
        Ad DeleteAd(int id);
        Ad UpdateAd(Ad ad);
    }
}
