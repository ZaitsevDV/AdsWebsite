using AW.Common.Models;
using System.Collections.Generic;

namespace AW.Web.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Phone NewPhone { get; set; }
        public Email NewEmail { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }
}