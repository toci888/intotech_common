namespace Intotech.Common.Bll.ChorDtoBll.Dto;

public class DtoBase<TModel, TModelDto> 
    where TModel : new()
    where TModelDto : new()
{
    public virtual DtoBase<TModel, TModelDto> MapModelToDto(TModel model)
    {
        return DtoModelMapper.Map<DtoBase<TModel, TModelDto>, TModel>(model);
    }

    public virtual TModel MapDtoToModel()
    {
        return DtoModelMapper.Map<TModel, DtoBase<TModel, TModelDto>>(this);
    }

    public virtual TModelDto MapDtoToDto()
    {
        return DtoModelMapper.Map<TModelDto, DtoBase<TModel, TModelDto>>(this);
    }
}