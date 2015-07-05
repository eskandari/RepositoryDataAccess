using System;
using System.Collections.Generic;
using System.Linq;
using PersianRug.Business.Entities;

namespace PersianRug.Data.Contracts
{
    public class CustomerAppointmentInfo
    {
        public Account Customer { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Appointment Appointment { get; set; }
    }
}