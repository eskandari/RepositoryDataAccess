using System;
using System.Collections.Generic;
using System.Linq;
using PersianRug.Business.Entities;
using Core.Common.Contracts;

namespace PersianRug.Data.Contracts
{
    public interface IReservationRepository : IDataRepository<Reservation>
    {
        IEnumerable<Reservation> GetReservationsByAppointmentDate(DateTime appointmentDate);
        IEnumerable<CustomerReservationInfo> GetCurrentCustomerReservationInfo();
        IEnumerable<CustomerReservationInfo> GetCustomerOpenReservationInfo(int accountId);
    }
}
