using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }
    }
}