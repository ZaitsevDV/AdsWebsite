using System;
using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class AdDetailsDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Picture { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public string LocationName { get; set; }

        [DataMember]
        public string TypeName { get; set; }

        [DataMember]
        public string ConditionName { get; set; }
    }
}