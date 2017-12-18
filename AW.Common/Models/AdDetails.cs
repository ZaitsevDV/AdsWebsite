using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AW.Common.Models
{
    public class AdDetails
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetic characters are allowed")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(0, double.MaxValue, ErrorMessage = "Check value")]
        public decimal Price { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Required field")]
        public string CategoryName { get; set; }

        [ReadOnly(true)]
        [DisplayName("Creation date")]
        [Required(ErrorMessage = "Required field")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreationDate { get; set; } = DateTime.Today;

        [DisplayName("Location")]
        public string LocationName { get; set; }

        public string TypeName { get; set; }

        [DisplayName("Condition")]
        public string ConditionName { get; set; }
    }
}
