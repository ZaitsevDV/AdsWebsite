using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone1 { get; set; }
        [DataMember]
        public string Phone2 { get; set; }
        [DataMember]
        public string Email1 { get; set; }
        [DataMember]
        public string Email2 { get; set; }
    }
}