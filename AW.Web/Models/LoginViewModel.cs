using System.ComponentModel.DataAnnotations;

namespace AW.Web.Models
{
    public class LoginViewModel
    {
        public string Message { get; set; }
        [Required(ErrorMessage = "Required field \"User name\"")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field \"Password\"")]
        public string Password { get; set; }
    }
}