using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Contracts;
using Core.Common;
using Core.Common.Data;

namespace PersianRug.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, PersianRugContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
