using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Intotech.Common.Bll.ChorDtoBll;

public abstract class DtoLogicBase<TModelDto, TModel, TLogic, TDto> : IDtoLogic<TModel, TLogic, TDto>
    where TLogic : ILogicBase<TModel>
    where TModelDto : DtoBase<TModel>, new()
    where TModel : class, new()
{
    protected TLogic CrudLogic;
    protected Expression<Func<TModel, bool>> SelectFilter;
    //protected Func<TDto, Func<TDto, TDto>, TModel>
    protected Func<TDto, TModelDto, TDto> UpdateModel;
    //protected Func<TDto, TModel> EntityGetter;

    protected DtoLogicBase(
        TLogic crudLogic, 
        Expression<Func<TModel, bool>> selectFilter,
        Func<TDto, TModelDto, TDto> updateModel
        //Func<TDto, TModel> entityGetter
        )
    {
        CrudLogic = crudLogic;
        SelectFilter = selectFilter;
        UpdateModel = updateModel;
        //EntityGetter = entityGetter;
    }

    public virtual TDto GetEntity(TDto masterEntity)
    {
        TModel result = CrudLogic.Select(SelectFilter).FirstOrDefault();

        if (result == null)
        {
            return masterEntity;
        }

        TModelDto entity = new TModelDto();

        return FillEntity(masterEntity, entity.MapModelToDto(result));
    }

    public virtual TDto SetEntity(TDto dtoToSet)
    {
        TModel entity = EntityGetter(dtoToSet);

        if (entity == null)
        {
            return dtoToSet;
        }

        entity = CrudLogic.Update(entity);
        TModelDto modelDto = DtoModelMapper.Map<TModelDto, TModel>(entity);
        dtoToSet = UpdateModel(dtoToSet, modelDto);

        return dtoToSet;
    }

    protected virtual TModel EntityGetter(TDto dto)
    {
        DtoBase<TModel> field = GetDtoModelField(dto);

        return field.MapDtoToModel();
    }

    protected abstract DtoBase<TModel> GetDtoModelField(TDto dto);
    protected abstract TDto FillEntity(TDto dto, DtoBase<TModel> field);
}