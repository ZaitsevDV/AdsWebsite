using System;
using System.ComponentModel.DataAnnotations;

namespace AW.Common.Models
{
    public class Ad
    {
        public int      Id           { get; set; }
        public string   UserName     { get; set; }
        [Required(ErrorMessage = "Required field")]
        //[RegularExpression(@"^[a-zA-Zd]*$", ErrorMessage = "Only alphabetic characters and digits are allowed")]
        public string   Title        { get; set; }
        public string   Description  { get; set; }
        public string   Picture      { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Range(0, double.MaxValue, ErrorMessage = "Check value")]
        public decimal  Price        { get; set; }
        public int      Category     { get; set; }
        [Required(ErrorMessage = "Required field")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreationDate { get; set; }
        public int      LocationId   { get; set; }
        public int      TypeId         { get; set; }
        public int      Condition    { get; set; }
    }
}