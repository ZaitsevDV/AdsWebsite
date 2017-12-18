using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class ConditionDto
    {
        [DataMember]
        public int ConditionId { get; set; }

        [DataMember]
        public string ConditionName { get; set; }
    }
}