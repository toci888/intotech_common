using System.Collections.Generic;
using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ChorDtoBll;

namespace Intotech.Common.Bll.ChorDtoBll;

public abstract class DtoLogicBase<TModelDto, TModel, TLogic, TDto, TCollectionModel, TCollectionModelDto> : IDtoLogicBase<TModelDto, TModel, TDto, TCollectionModel, TCollectionModelDto> 
    where TLogic : ILogicBase<TModel>
    where TModelDto : DtoCollectionBase<TModel, TModelDto, TCollectionModel, TCollectionModelDto>, new()
    where TModel : ModelBase, new()
    where TCollectionModel : IList<TModel>, new()
    where TCollectionModelDto : IList<TModelDto>, new()
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

    public virtual TCollectionModelDto GetCollection()
    {
        IList<TModel> collection = CrudLogic.Select(SelectFilter).ToList();

        if (collection == null)
        {
            return default;
        }

        TCollectionModelDto entityCollection = new TCollectionModelDto();

        foreach (TModel element in collection)
        {
            TModelDto item = new TModelDto();

            entityCollection.Add(item.MapModelToDto(element));
        }

        //outputField = entityCollection;

        return entityCollection;
    }

    public virtual bool SetCollection(TCollectionModelDto entityCollection)
    {
        foreach (TModelDto element in entityCollection)
        {
            TModel item = element.MapDtoToModel();

            if (item.Id > 0)
            {
                CrudLogic.Update(item);
            }
            else
            {
                CrudLogic.Insert(item);
            }
        }

        return true;
    }

    public virtual TDto GetEntity(TDto masterEntity, TCollectionModelDto outputField = default)
    {
        if (outputField != null)
        {

        }

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
    protected abstract TDto FillEntity(TDto dto, TCollectionModelDto field);
}