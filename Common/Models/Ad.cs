using System;


namespace Common.Models
{
    public class Ad
    {
        public int Id { get; }
        public int CreatorId { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public bool Type { get; set; }
        public bool Condition { get; set; }
    }
}
