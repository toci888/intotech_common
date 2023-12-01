using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database
{
    public class DbHandleManager<TModel> : DbContext, IDbHandleManager<TModel>, IDbContextFactory<DbContext> where TModel : ModelBase
    {
        private DbContext databaseHandle;

        public DbHandleManager(DbContext databaseHandle)
        {
            this.databaseHandle = databaseHandle;
        }
        public DbHandleManager(DbContext databaseHandle, DbHandleType type)
        {
            //this.GetInstance(type);
        }

        public DbContext CreateDbContext()
        {
            return this;
        }

        public virtual IDbHandle<TModel> GetInstance(DbHandleType dbHandleType, DbContext databaseHandle)
        {
            if (dbHandleType == DbHandleType.TypeSc)
            {
                return new DbHandleCriticalSection<TModel>(databaseHandle, DbHandleType.TypeSc);
            }

            return new DbHandleMultiThreading<TModel>(databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(DbContext databaseHandle, DbHandleType dbHandleType)
        {
            return GetInstance(dbHandleType, databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(DbHandleType dbHandleType)
        {
            throw new NotImplementedException();
        }
    }
}
