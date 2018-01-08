using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Business.Providers
{
    public interface IAdProvider
    {
        void CreateAd(Ad ad);
        void EditeAd(Ad ad);
        void DeleteAd(int adId);
        List<Ad> GetAds { get; }
        AdDetails GetAdDetails(int id);
        List<Ad> GetAdsByCategory(int categoryId);
        List<Category> GetCategories { get; }
        List<Condition> GetConditions { get; }
        List<Location> GetLocations { get; }
        List<AdType> GetTypes { get; }
    }
}