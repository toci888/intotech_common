using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.Interfaces
{
    public interface IDbHandleManager<TModel>
    {
        IDbHandle<TModel> GetInstance(DbHandleType dbHandleType);
    }
}
