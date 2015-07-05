using System;
using Core.Common.Core;
using FluentValidation;

namespace PersianRug.Client.Entities
{
    public class TimeSlot : ObjectBase
    {
        int _TimeSlotId;
        string _Description;
        DateTime _StartTime;
        DateTime _EndTime;
        bool _CurrentlyBooked;

        public int TimeSlotId
        {
            get { return _TimeSlotId;}
            set
            {
                if (_TimeSlotId != value)
                {
                    _TimeSlotId = value;
                    OnPropertyChanged(() => _TimeSlotId);
                }
            }
        }

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => _Description);
                }
            }
        }


        public DateTime StartTime
        {
            get { return _StartTime; }
            set
            {
                if (_StartTime != value)
                {
                    _StartTime = value;
                    OnPropertyChanged(() => _StartTime);
                }
            }
        }


        public DateTime EndTime
        {
            get { return _EndTime; }
            set
            {
                if (_EndTime != value)
                {
                    _EndTime = value;
                    OnPropertyChanged(() => _EndTime);
                }
            }
        }

        public bool CurrentlyBooked
        {
            get { return _CurrentlyBooked; }
            set
            {
                if (_CurrentlyBooked != value)
                {
                    _CurrentlyBooked = value;
                    OnPropertyChanged(() => _CurrentlyBooked);
                }
            }
        }
        
        class TimeSlotValidator : AbstractValidator<TimeSlot>
        {
            public TimeSlotValidator()
            {
                RuleFor(obj => obj.Description).NotEmpty();
                RuleFor(obj => obj.StartTime).NotEmpty();
                RuleFor(obj => obj.EndTime).NotEmpty();
                RuleFor(obj => obj.CurrentlyBooked).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new TimeSlotValidator();
        }
    }
}
