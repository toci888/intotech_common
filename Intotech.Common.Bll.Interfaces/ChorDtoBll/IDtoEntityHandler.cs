namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoEntityHandler<TDto, in TCollectionModelDto>
{
    //TDto GetEntity(TDto masterEntity, TCollectionModelDto outputField = default);

    TDto SetEntity(TDto dtoToSet);
}