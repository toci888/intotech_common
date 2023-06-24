using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoLogic<out TModel, out TLogic, TDto, in TCollectionModelDto> : IDtoEntityHandler<TDto, TCollectionModelDto>
    where TLogic : ILogicBase<TModel>
    where TModel : class
{
    
}