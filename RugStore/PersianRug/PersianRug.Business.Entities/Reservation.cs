using System;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace PersianRug.Business.Entities
{
    [DataContract]
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int ReservationId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int TimeSlotId { get; set; }

        [DataMember]
        public DateTime BookDate { get; set; }


        #region IIdentifiableEntity members

        public int EntityId
        {
            get { return ReservationId; }
            set { ReservationId = value; }
        }

        #endregion

        #region IAccountOwnedEntity members

        int IAccountOwnedEntity.OwnerAccountId
        {
            get { return AccountId; }
        }

        #endregion
    }
}
