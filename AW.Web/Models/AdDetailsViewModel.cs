using AW.Common.Models;
using System.Collections.Generic;

namespace AW.Web.Models
{
    public class AdDetailsViewModel
    {
        public AdDetails Ad { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }
}