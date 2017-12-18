using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class PhoneDto
    {
        [DataMember]
        public int PhoneId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}