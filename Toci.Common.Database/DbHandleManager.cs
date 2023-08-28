using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database
{
    public class DbHandleManager<TModel> : IDbHandleManager<TModel> where TModel : ModelBase
    {
        public virtual IDbHandle<TModel> GetInstance(DbHandleType dbHandleType)
        {
            if (dbHandleType == DbHandleType.TypeSc)
            {
                return new DbHandleSc<TModel>();
            }
            
            return new DbHandleMt<TModel>();
        }
    }
}
