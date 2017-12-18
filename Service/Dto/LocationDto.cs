using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class LocationDto
    {
        [DataMember]
        public int LocationId { get; set; }

        [DataMember]
        public string LocationName { get; set; }
    }
}