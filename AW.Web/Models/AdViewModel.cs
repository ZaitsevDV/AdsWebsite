using AW.Common.Models;
using System;
using System.Collections.Generic;
using AW.Business.Authorization;

namespace AW.Web.Models
{
    public class AdViewModel
    {
        public Ad Ad { get; set; }
        public UserPrincipal User { get; set; }
        public List<Category> Categories { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<Location> Locations { get; set; }
        public List<AdType> Types { get; set; }
        public bool New { get; set; }
    }
}