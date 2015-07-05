using System;
using Core.Common.Core;

namespace PersianRug.Client.Entities
{
    public class Reservation : ObjectBase
    {
        int _ReservationId;
        int _AccountId;
        int _TimeSlotId;
        DateTime _BookDate;

        public int ReservationId
        {
            get { return _ReservationId; }
            set
            {
                if (_ReservationId != value)
                {
                    _ReservationId = value;
                    OnPropertyChanged(() => ReservationId);
                }
            }
        }

        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        public int TimeSlotId
        {
            get { return _TimeSlotId; }
            set
            {
                if (_TimeSlotId != value)
                {
                    _TimeSlotId = value;
                    OnPropertyChanged(() => TimeSlotId);
                }
            }
        }

        public DateTime BookDate
        {
            get { return _BookDate; }
            set
            {
                if (_BookDate != value)
                {
                    _BookDate = value;
                    OnPropertyChanged(() => BookDate);
                }
            }
        }
    }
}
