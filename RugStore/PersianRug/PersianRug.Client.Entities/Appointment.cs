using System;
using Core.Common.Core;

namespace PersianRug.Client.Entities
{
  public class Rental : ObjectBase
    {
        int _AppointmentId;
        int _AccountId;
        int _TimeSlotId;
        DateTime _AppointmentDate;

        public int AppointmentId
        {
            get { return _AppointmentId; }
            set
            {
                if (_AppointmentId != value)
                {
                    _AppointmentId = value;
                    OnPropertyChanged(() => _AppointmentId);
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
                    OnPropertyChanged(() => _TimeSlotId);
                }
            }
        }

        public DateTime AppointmentDate
        {
            get { return _AppointmentDate; }
            set
            {
                if (_AppointmentDate != value)
                {
                    _AppointmentDate = value;
                    OnPropertyChanged(() => _AppointmentDate);
                }
            }
        }
    }
}
