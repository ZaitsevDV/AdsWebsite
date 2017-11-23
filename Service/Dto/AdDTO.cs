using System.Runtime.Serialization;

namespace Service.Dto
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
