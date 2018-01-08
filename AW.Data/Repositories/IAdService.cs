using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Data.Repositories
{
    public interface IAdService
    {
        void CreateAd(Ad ad);
        void EditeAd(Ad ad);
        void DeleteAd(int adId);
        List<Ad> GetAds();
        List<Ad> GetAdsByCategory(int categoryId);
        AdDetails GetAdDetails(int id);
        List<Category> GetCategories();
        List<Condition> GetConditions();
        List<Location> GetLocations();
        List<AdType> GetTypes();
    }
}