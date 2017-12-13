using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAds();
        List<Ad> GetAdsByCategory(int categoryId);
        Ad GetAdDetails(int id);
        List<Category> GetCategories();

    }
}
