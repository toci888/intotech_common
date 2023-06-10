using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoLogic<out TModel, out TLogic, TDto> : IDtoEntityHandler<TDto>
    where TLogic : ILogicBase<TModel>
    where TModel : class
{
    
}