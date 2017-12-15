using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int ParentCategoryId { get; set; }
    }
}