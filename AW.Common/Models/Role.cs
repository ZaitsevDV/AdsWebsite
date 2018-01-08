using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AW.Common.Models
{
    public class Role
    {
        [DisplayName("Role")]
        [Required(ErrorMessage = "Required field")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}