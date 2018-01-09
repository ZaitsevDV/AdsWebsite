using AW.Common.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace AW.Web.Models
{
    public class AdViewModel
    {
        public Ad Ad { get; set; }
        public List<AdType> AdType { get; set; }
        [DisplayName("Image")]
        public HttpPostedFileBase UploadImage { get; set; }
        public bool New { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }

    }
}