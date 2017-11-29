namespace Common.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParientCategoryId { get; set; }
    }
}
