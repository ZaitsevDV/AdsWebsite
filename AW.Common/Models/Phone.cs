using System.ComponentModel.DataAnnotations;

namespace AW.Common.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string UserName { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only digits are allowed")]
        public string PhoneNumber { get; set; }
    }
}
