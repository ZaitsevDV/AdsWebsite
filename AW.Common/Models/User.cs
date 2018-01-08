using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AW.Common.Models
{
    public class User
    {
        [DisplayName("User name")]
        [Required(ErrorMessage = "Required field")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}