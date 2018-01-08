using System.ComponentModel.DataAnnotations;

namespace AW.Web.Models
{
    public class LoginViewModel
    {
        public string Message { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Password { get; set; }
    }
}