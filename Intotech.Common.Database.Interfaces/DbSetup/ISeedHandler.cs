using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.Interfaces.DbSetup
{
    public interface ISeedHandler
    {
        bool AddEntity(object modelEntity);

        bool SeedCollection();
    }
}
