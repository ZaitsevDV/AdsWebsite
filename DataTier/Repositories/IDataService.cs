using Common.Models;
using System.Collections.Generic;

namespace DataTier.Repositories
{
    public interface IDataService
    {
        IEnumerable<Ad> GetAds();
        Ad GetAdDetails(int id);
        List<Category> GetCategories();
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
    }
}
