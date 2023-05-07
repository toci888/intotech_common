using Intotech.Common.Database.Interfaces.DbSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class SeedHandler<TModel> : ISeedHandler<TModel>
    {
        public virtual bool AddEntity(TModel modelEntity)
        {
            throw new NotImplementedException();
        }

        public virtual bool SeedCollection()
        {
            throw new NotImplementedException();
        }
    }
}
