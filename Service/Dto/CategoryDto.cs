using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int ParientCategoryId { get; set; }
    }
}