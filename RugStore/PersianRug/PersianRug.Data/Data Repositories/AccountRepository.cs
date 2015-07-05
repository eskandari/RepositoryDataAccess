using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PersianRug.Business.Entities;
using PersianRug.Data.Contracts;

namespace PersianRug.Data
{    
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(PersianRugContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(PersianRugContext entityContext, Account entity)
        {
            return (from e in entityContext.AccountSet
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Account> GetEntities(PersianRugContext entityContext)
        {
            return from e in entityContext.AccountSet
                   select e;
        }
        
        protected override Account GetEntity(PersianRugContext entityContext, int id)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountId == id
                         select e);
            
            var results = query.FirstOrDefault();

            return results;
        }

        public Account GetByLogin(string login)
        {
            using (PersianRugContext entityContext = new PersianRugContext())
            {
                return (from a in entityContext.AccountSet
                        where a.LoginEmail == login
                        select a).FirstOrDefault();
            }
        }
    }
}
