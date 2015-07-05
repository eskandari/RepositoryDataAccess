using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using PersianRug.Data;

namespace PersianRug.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AccountRepository).Assembly));
            
            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
