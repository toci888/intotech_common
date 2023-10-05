using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ComplexResponses;
using Intotech.Common.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll
{
    public abstract class StandardControllerManager<TILogic, TModel, TModelDto> : IStandardControllerManager<TILogic, TModel, TModelDto>
        where TModel : ModelBase
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoEntityBase
    {
        public ReturnedResponse<TModelDto> GetSingle(Expression<Func<TModel, TModelDto, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
