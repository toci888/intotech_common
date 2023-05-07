using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.Interfaces.DbSetup
{
    public interface ISeedHandler<TModel>
    {
        bool AddEntity(TModel modelEntity);

        bool SeedCollection();
    }
}
