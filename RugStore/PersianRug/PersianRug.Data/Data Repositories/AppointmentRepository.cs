using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PersianRug.Business.Entities;
using PersianRug.Data.Contracts;
using Core.Common.Extensions;

namespace PersianRug.Data
{
    [Export(typeof(IAppointmentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AppointmentRepository : DataRepositoryBase<Appointment>, IAppointmentRepository
    {
        protected override Appointment AddEntity(PersianRugContext entityContext, Appointment entity)
        {
            return entityContext.AppointmentSet.Add(entity);
        }

        protected override Appointment UpdateEntity(PersianRugContext entityContext, Appointment entity)
        {
            return (from e in entityContext.AppointmentSet
                    where e.AppointmentId == entity.AppointmentId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Appointment> GetEntities(PersianRugContext entityContext)
        {
            return from e in entityContext.AppointmentSet
                   select e;
        }

        protected override Appointment GetEntity(PersianRugContext entityContext, int id)
        {
            var query = (from e in entityContext.AppointmentSet
                         where e.AppointmentId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<Appointment> GetAppointmentHistoryByTimeSlot(int timeSlotId)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from e in entityContext.AppointmentSet
                            where e.TimeSlotId == timeSlotId
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public Appointment GetCurrentAppointmentByTimeSlot(int timeSlotId)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from e in entityContext.AppointmentSet
                            where e.TimeSlotId == timeSlotId
                            select e;

                return query.FirstOrDefault();
            }
        }

        public IEnumerable<Appointment> GetCurrentlyAppointments()
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from e in entityContext.AppointmentSet
                            where e.AppointmentDate > DateTime.Now && e.AppointmentDate < DateTime.Now.AddDays(7)
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<Appointment> GetAppointmentHistoryByAccount(int accountId)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from e in entityContext.AppointmentSet
                            where e.AccountId == accountId
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<CustomerAppointmentInfo> GetCurrentCustomerAppointmentInfo()
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from r in entityContext.AppointmentSet
                            join a in entityContext.AccountSet on r.AccountId equals a.AccountId
                            join c in entityContext.TimeSlotSet on r.TimeSlotId equals c.TimeSlotId
                            select new CustomerAppointmentInfo()
                            {
                                Customer = a,
                                TimeSlot = c,
                                Appointment = r
                            };

                return query.ToFullyLoaded();
            }
        }


        public Appointment GetAppointmentByTimeSlot(int timeSlotId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetCurrentAppointmentS()
        {
            throw new NotImplementedException();
        }
    }
}
