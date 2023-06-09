using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Intotech.Common.Bll.ChorDtoBll;

public abstract class DtoLogicBase<TModel, TLogic, TDto> : IDtoLogic<TModel, TLogic, TDto>
    where TLogic : ILogicBase<TModel>
    where TModel : class
{
    protected TLogic CrudLogic;
    protected Expression<Func<TModel, bool>> SelectFilter;

    protected DtoLogicBase(TLogic crudLogic, Expression<Func<TModel, bool>> selectFilter)
    {
        CrudLogic = crudLogic;
        SelectFilter = selectFilter;
    }

    public virtual TDto GetEntity(TDto masterEntity)
    {
        TModel result = CrudLogic.Select(SelectFilter).FirstOrDefault();

        return FillEntity(masterEntity, result);
    }

    protected abstract TDto FillEntity(TDto dto, TModel field);
}