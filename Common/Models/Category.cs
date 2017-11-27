namespace Common.Models
{
    public class Category
    {
        public Category()
        {
            
        }

        public Category(int id, string categoryName, int parientCategoryId)
        {
            Id = id;
            CategoryName = categoryName;
            ParientCategoryId = parientCategoryId;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParientCategoryId { get; set; }
    }
}
