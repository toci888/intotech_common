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
    //protected Func<TDto, Func<TDto, TDto>, TModel>
    protected Func<TDto, TModel, TDto> UpdateModel;
    protected Func<TDto, TModel> EntityGetter;

    protected DtoLogicBase(
        TLogic crudLogic, 
        Expression<Func<TModel, bool>> selectFilter,
        Func<TDto, TModel, TDto> updateModel,
        Func<TDto, TModel> entityGetter)
    {
        CrudLogic = crudLogic;
        SelectFilter = selectFilter;
        UpdateModel = updateModel;
        EntityGetter = entityGetter;
    }

    public virtual TDto GetEntity(TDto masterEntity)
    {
        TModel result = CrudLogic.Select(SelectFilter).FirstOrDefault();

        return FillEntity(masterEntity, result);
    }

    public virtual TDto SetEntity(TDto dtoToSet)
    {
        TModel entity = EntityGetter(dtoToSet);

        if (entity == null)
        {
            return dtoToSet;
        }

        entity = CrudLogic.Update(entity);
        dtoToSet = UpdateModel(dtoToSet, entity);

        return dtoToSet;
    }

    protected abstract TDto FillEntity(TDto dto, TModel field);
}