using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Data.Repositories
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAds();
        List<Ad> GetAdsByCategory(int categoryId);
        Ad GetAdDetails(int id);
        List<Category> GetCategories();
    }
}