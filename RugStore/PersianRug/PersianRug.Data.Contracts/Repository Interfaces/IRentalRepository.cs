using System;
using System.Collections.Generic;
using System.Linq;
using PersianRug.Business.Entities;
using Core.Common.Contracts;

namespace PersianRug.Data.Contracts
{
    public interface IAppointmentRepository : IDataRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentHistoryByTimeSlot(int timeSlotId);
        Appointment GetAppointmentByTimeSlot(int timeSlotId);
        IEnumerable<Appointment> GetCurrentAppointmentS();
        IEnumerable<Appointment> GetAppointmentHistoryByAccount(int accountId);
        IEnumerable<CustomerAppointmentInfo> GetCurrentCustomerAppointmentInfo();
    }
}
