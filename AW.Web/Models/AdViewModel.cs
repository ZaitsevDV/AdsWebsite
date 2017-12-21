using System.Collections.Generic;
using AW.Common.Models;
using System.Web;

namespace AW.Web.Models
{
    public class AdViewModel
    {
        public Ad Ad { get; set; }
        public List<AdType> AdType { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public bool New { get; set; }
    }
}