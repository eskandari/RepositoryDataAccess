using System;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace PersianRug.Business.Entities
{
    [DataContract]
    public class TimeSlot : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int TimeSlotId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public bool CurrentlyBooked { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get { return TimeSlotId; }
            set { TimeSlotId = value; }
        }

        #endregion
    }
}
