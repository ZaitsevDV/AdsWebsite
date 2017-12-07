using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }
}