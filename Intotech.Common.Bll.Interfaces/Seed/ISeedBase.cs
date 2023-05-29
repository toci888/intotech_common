using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces.Seed
{
    public interface ISeedBase<TModel> : ILogicBase<TModel> where TModel : class
    {
    }
}
