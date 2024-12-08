using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Database
{
    public class DbHandleManager<TModel> : DbContext, IDbHandleManager<TModel>, IDbContextFactory<DbContext> where TModel : ModelBase
    {
        private DbContext databaseHandle;

        public DbHandleManager(DbContext databaseHandle)
        {
            this.databaseHandle = databaseHandle;
        }
  
        public DbContext CreateDbContext()
        {
            return this;
        }

        public virtual IDbHandle<TModel> GetInstance(DbHandleType dbHandleType, DbContext databaseHandle, IErrorLogger logger)
        {
            if (dbHandleType == DbHandleType.TypeSc)
            {
                return new DbHandleCriticalSection<TModel>(databaseHandle, DbHandleType.TypeSc, logger);
            }

            return new DbHandleMultiThreading<TModel>(databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(DbContext databaseHandle, DbHandleType dbHandleType, IErrorLogger errorLogger)
        {
            return GetInstance(dbHandleType, databaseHandle, errorLogger);
        }

        public IDbHandle<TModel> GetInstance(DbHandleType dbHandleType)
        {
            throw new NotImplementedException();
        }
    }
}
