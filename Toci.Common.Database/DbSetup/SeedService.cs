using Intotech.Common.Database.Interfaces.DbSetup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class SeedService : ISeedService
    {
        protected ISeedManager<DbContext> DbSeedManager;

        public virtual bool AcceptManager(ISeedManager<DbContext> seedManager)
        {
            DbSeedManager = seedManager;

            return true;
        }

        public virtual bool RunSeed()
        {
            return DbSeedManager.SeedAllDb();
        }
    }
}
