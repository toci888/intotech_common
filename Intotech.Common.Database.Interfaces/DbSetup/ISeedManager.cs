
using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Database.Interfaces.DbSetup
{
    public interface ISeedManager<TDbContext> where TDbContext : DbContext
    {
        bool SeedAllDb();
    }
}
