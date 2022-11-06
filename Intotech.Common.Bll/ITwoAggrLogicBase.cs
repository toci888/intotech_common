using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll
{
    public abstract class TwoAggrLogicBase<TFirstLogic, TSecondLogic> : ITwoAggrLogicBase<TFirstLogic, TSecondLogic>
    {
        protected TFirstLogic FirstLogic;
        protected TSecondLogic SecondLogic;

        protected TwoAggrLogicBase(TFirstLogic firstLogic, TSecondLogic secondLogic)
        {
            FirstLogic = firstLogic;
            SecondLogic = secondLogic;
        }
    }
}
