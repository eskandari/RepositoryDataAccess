using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PersianRug.Business.Entities;
using PersianRug.Data.Contracts;
using Core.Common.Extensions;

namespace PersianRug.Data
{
    [Export(typeof(ITimeSlotRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TimeSlotRepository : DataRepositoryBase<TimeSlot>, ITimeSlotRepository
    {
        protected override TimeSlot AddEntity(PersianRugContext entityContext, TimeSlot entity)
        {
            return entityContext.TimeSlotSet.Add(entity);
        }

        protected override TimeSlot UpdateEntity(PersianRugContext entityContext, TimeSlot entity)
        {
            return (from e in entityContext.TimeSlotSet
                    where e.TimeSlotId == entity.TimeSlotId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<TimeSlot> GetEntities(PersianRugContext entityContext)
        {
            return from e in entityContext.TimeSlotSet
                   select e;
        }

        protected override TimeSlot GetEntity(PersianRugContext entityContext, int id)
        {
            var query = (from e in entityContext.TimeSlotSet
                         where e.TimeSlotId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
