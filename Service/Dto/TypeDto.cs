using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class TypeDto
    {
        [DataMember]
        public int TypeId { get; set; }

        [DataMember]
        public string TypeName { get; set; }
    }
}