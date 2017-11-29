using System.Collections.Generic;

namespace Common.Models
{
    public class CategoryContainer
    {
        public int ParentId { get; set; }
        public IList<Category> Categories { get; set; }

        public CategoryContainer()
        { }

        public CategoryContainer(int parentId, IList<Category> categories)
        {
            ParentId = parentId;
            Categories = categories;
        }
    }
}
