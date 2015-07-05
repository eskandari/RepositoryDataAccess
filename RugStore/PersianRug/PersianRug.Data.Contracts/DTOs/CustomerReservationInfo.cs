using System;
using System.Collections.Generic;
using System.Linq;
using PersianRug.Business.Entities;

namespace PersianRug.Data.Contracts
{
    public class CustomerReservationInfo
    {
        public Account Customer { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Reservation Reservation { get; set; }
    }
}
