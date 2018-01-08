using System.ComponentModel.DataAnnotations;

namespace AW.Web.Models
{
    public class PasswordViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Do not match")]
        public string RePassword { get; set; }

    }
}