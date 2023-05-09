using Intotech.Common.Database.Interfaces.DbSetup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public abstract class SeedManagerBase<TDbContext> : ISeedManager<TDbContext> where TDbContext : DbContext
    {
        protected List<SeedHandler> SeedHandlers = new List<SeedHandler>();

        protected TDbContext DbContext { get; set; }

        protected SeedManagerBase(TDbContext dbContext) 
        {
            DbContext = dbContext;
        }

        public virtual bool SeedAllDb()
        {
            foreach (SeedHandler handler in SeedHandlers) 
            {
                handler.SeedCollection();
            }

            return true;
        }
    }
}
