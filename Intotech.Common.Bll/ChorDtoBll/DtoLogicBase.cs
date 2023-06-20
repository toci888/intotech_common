using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ChorDtoBll;

namespace Intotech.Common.Bll.ChorDtoBll;

public abstract class DtoLogicBase<TModelDto, TModel, TLogic, TDto> : IDtoLogic<TModel, TLogic, TDto>
    where TLogic : ILogicBase<TModel>
    where TModelDto : DtoBase<TModel, TModelDto>, new()
    where TModel : class, new()
{
    protected TLogic CrudLogic;
    protected Expression<Func<TModel, bool>> SelectFilter;
    protected Func<TDto, TModelDto, TDto> UpdateModel;

    protected DtoLogicBase(
        TLogic crudLogic,
        Func<TDto, TModelDto, TDto> updateModel
    )
    {
        CrudLogic = crudLogic;
        UpdateModel = updateModel;
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

    public virtual void SetSelectFilter(Expression<Func<TModel, bool>> selectFilter)
    {
        SelectFilter = selectFilter;
    }

    protected virtual TModel EntityGetter(TDto dto)
    {
        DtoBase<TModel, TModelDto> field = GetDtoModelField(dto);

        return field.MapDtoToModel();
    }

    protected abstract DtoBase<TModel, TModelDto> GetDtoModelField(TDto dto);
    protected abstract TDto FillEntity(TDto dto, TModelDto field);
}