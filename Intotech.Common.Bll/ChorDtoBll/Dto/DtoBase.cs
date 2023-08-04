using Intotech.Common.Bll.Interfaces;

namespace Intotech.Common.Bll.ChorDtoBll.Dto;

public class DtoBase<TModel, TModelDto> 
    where TModel : ModelBase, new()
    where TModelDto : new() //DtoBase<TModel, TModelDto>, 
{
   /* public virtual TModelDto MapModelToDto(TModel model)
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
    }*/
}