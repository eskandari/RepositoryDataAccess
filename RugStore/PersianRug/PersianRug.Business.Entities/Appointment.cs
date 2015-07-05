using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;

namespace PersianRug.Business.Entities
{
    [DataContract]
    public class Appointment : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int AppointmentId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int TimeSlotId { get; set; }

        [DataMember]
        public DateTime AppointmentDate { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get { return AppointmentId; }
            set { AppointmentId = value; }
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
