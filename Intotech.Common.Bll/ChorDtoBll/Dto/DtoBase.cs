﻿namespace Intotech.Common.Bll.ChorDtoBll.Dto;

public class DtoBase<TModel, TModelDto> 
    where TModel : new()
    where TModelDto : DtoBase<TModel, TModelDto>, new()
{
    public virtual TModelDto MapModelToDto(TModel model)
    {
        return DtoModelMapper.Map<TModelDto, TModel>(model);
    }

    public virtual TModel MapDtoToModel()
    {
        return DtoModelMapper.Map<TModel, TModelDto>((TModelDto)this);
    }

    public virtual TModelDto MapDtoToDto()
    {
        return DtoModelMapper.Map<TModelDto, TModelDto>((TModelDto)this);
    }
}