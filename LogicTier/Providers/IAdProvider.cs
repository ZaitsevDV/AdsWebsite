using Common.Models;
using System.Collections.Generic;

namespace LogicTier.Providers
{
    public interface IAdProvider
    {
        Ad GetAdDetails(int id);
        IEnumerable<Ad> GetAds { get; }
        IEnumerable<User> GetUsers { get; }
        List<Category> GetCategories { get; }
    }
}
