using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class AdDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

}
