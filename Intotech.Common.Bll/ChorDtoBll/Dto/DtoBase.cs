namespace Intotech.Common.Bll.ChorDtoBll.Dto;

public class DtoBase<TModel> where TModel : new()
{
    public virtual DtoBase<TModel> MapModelToDto(TModel model)
    {
        return DtoModelMapper.Map<DtoBase<TModel>, TModel>(model);
    }

    public virtual TModel MapDtoToModel()
    {
        return DtoModelMapper.Map<TModel, DtoBase<TModel>>(this);
    }
}