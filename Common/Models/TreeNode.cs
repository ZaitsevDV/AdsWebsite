using System.Collections.Generic;

namespace Common.Models
{
    public class TreeNode
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public TreeNode ParentCategory { get; set; }
        public List<TreeNode> Children { get; set; }
    }
}