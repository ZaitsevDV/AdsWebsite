using System;

namespace AW.Common.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public DateTime CreationDate { get; set; }
        public int LocationId { get; set; }
        public int Type { get; set; }
        public int Condition { get; set; }
    }
}