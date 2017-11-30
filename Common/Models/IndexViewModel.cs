using System.Collections.Generic;

namespace Common.Models
{
    public class IndexViewModel
    {
        public int CategoryParentId { get; set; }
        public IList<Category> Categories { get; set; }
        public IEnumerable<Ad> Ads { get; set; }

        public IndexViewModel(int parentId, IList<Category> categories, IEnumerable<Ad> ads)
        {
            CategoryParentId = parentId;
            Categories = categories;
            Ads = ads;
        }
    }
}