using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoLogic<out TModel, TLogic, TDto> 
    where TLogic : ILogicBase<TModel>
    where TModel : class
{
    TDto GetEntity(TDto masterEntity);
}