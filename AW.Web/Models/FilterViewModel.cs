using System.Collections.Generic;
using System.ComponentModel;
using AW.Common.Models;

namespace AW.Web.Models
{
    public class FilterViewModel
    {
        public string Title { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Type")]
        public int TypeId { get; set; }

        public List<Ad> Ads { get; set; }
        public List<AdType> Types { get; set; }
        public List<Category> Categories { get; set; }
    }
}