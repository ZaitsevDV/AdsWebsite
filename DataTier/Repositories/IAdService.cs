using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAds();
        Ad GetAdDetails(int id);
        List<Category> GetCategories();
    }
}
