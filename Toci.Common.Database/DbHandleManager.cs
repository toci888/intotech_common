using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database
{
    public class DbHandleManager<TModel> : IDbHandleManager<TModel> where TModel : ModelBase
    {
        private Func<DbContext> databaseHandle;

        public DbHandleManager(Func<DbContext> databaseHandle)
        {
            this.databaseHandle = databaseHandle;
        }
        public DbHandleManager(Func<DbContext> databaseHandle, DbHandleType type)
        {
            //this.GetInstance(type);
        }

        public virtual IDbHandle<TModel> GetInstance(DbHandleType dbHandleType, Func<DbContext> databaseHandle)
        {
            if (dbHandleType == DbHandleType.TypeSc)
            {
                return new DbHandleCriticalSection<TModel>(databaseHandle, DbHandleType.TypeSc);
            }

            return new DbHandleMultiThreading<TModel>(databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(Func<DbContext> databaseHandle, DbHandleType dbHandleType)
        {
            return GetInstance(dbHandleType, databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(DbHandleType dbHandleType)
        {
            throw new NotImplementedException();
        }
    }
}
