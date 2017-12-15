using System.Collections.Generic;
using AW.Common.Models;

namespace AW.Business.Providers
{
    public interface IAdProvider
    {
        IEnumerable<Ad> GetAds { get; }
        List<Category> GetCategories { get; }
        Ad GetAdDetails(int id);
        List<Ad> GetAdsByCategory(int categoryId);
    }
}