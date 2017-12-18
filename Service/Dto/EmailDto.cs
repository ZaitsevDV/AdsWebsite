using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class EmailDto
    {
        [DataMember]
        public int EmailId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string EmailValue { get; set; }
    }
}