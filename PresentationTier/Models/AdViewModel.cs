using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common.Models;

namespace PresentationTier.Models
{
    public class AdViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public int Id { get; set; }

        //[Display(Name = "Name goods")]
        //[Required(ErrorMessage = ("Goods name is required.")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Name { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "Please enter a description")]
        //public string Description { get; set; }

        //[Required]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        //public decimal Price { get; set; }

        //[Required(ErrorMessage = "Please specify a category")]
        //public string Category { get; set; }

        //[Required(ErrorMessage = "Please specify a subcategory")]
        //public string SubCategory { get; set; }

        //[ReadOnly(true)]
        //[Display(Name = "Creation data")]
        //public DateTime CreationDate { get; set; } = DateTime.Today;

        //public string Location { get; set; }
        //public bool Type { get; set; }
        //public bool Condition { get; set; }

    }
}