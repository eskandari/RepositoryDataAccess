using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PersianRug.Business.Entities;
using PersianRug.Data.Contracts;
using Core.Common.Extensions;

namespace PersianRug.Data
{
    [Export(typeof(IReservationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReservationRepository : DataRepositoryBase<Reservation>, IReservationRepository
    {
        protected override Reservation AddEntity(PersianRugContext entityContext, Reservation entity)
        {
            return entityContext.ReservationSet.Add(entity);
        }

        protected override Reservation UpdateEntity(PersianRugContext entityContext, Reservation entity)
        {
            return (from e in entityContext.ReservationSet
                    where e.ReservationId == entity.ReservationId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Reservation> GetEntities(PersianRugContext entityContext)
        {
            return from e in entityContext.ReservationSet
                   select e;
        }

        protected override Reservation GetEntity(PersianRugContext entityContext, int id)
        {
            var query = (from e in entityContext.ReservationSet
                         where e.ReservationId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<CustomerReservationInfo> GetCurrentCustomerReservationInfo()
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from r in entityContext.ReservationSet
                            join a in entityContext.AccountSet on r.AccountId equals a.AccountId
                            join c in entityContext.TimeSlotSet on r.TimeSlotId equals c.TimeSlotId
                            select new CustomerReservationInfo()
                            {
                                Customer = a,
                                TimeSlot = c,
                                Reservation = r
                            };

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<Reservation> GetReservationsByAppointmentDate(DateTime appointmentDate)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from r in entityContext.ReservationSet
                            where r.BookDate < appointmentDate
                            select r;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<CustomerReservationInfo> GetCustomerOpenReservationInfo(int accountId)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                var query = from r in entityContext.ReservationSet
                            join a in entityContext.AccountSet on r.AccountId equals a.AccountId
                            join c in entityContext.TimeSlotSet on r.TimeSlotId equals c.TimeSlotId
                            where r.AccountId == accountId
                            select new CustomerReservationInfo()
                            {
                                Customer = a,
                                TimeSlot = c,
                                Reservation = r
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
