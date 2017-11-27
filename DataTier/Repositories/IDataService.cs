using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IDataService
    {
        IEnumerable<Ad> GetAds();
        Ad GetAdDetails(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<User> GetUsers();
    }
}
