using System;
using System.Runtime.Serialization;

namespace Service.Dto
{
    [DataContract]
    public class AdDto
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
        public int CategoryId { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public int LocationId { get; set; }

        [DataMember]
        public int TypeId { get; set; }

        [DataMember]
        public int ConditionId { get; set; }
    }
}