﻿using System;
using System.Collections.Generic;
using System.Linq;
using PersianRug.Business.Entities;
using Core.Common.Contracts;

namespace PersianRug.Data.Contracts
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        Account GetByLogin(string login);
    }
}
