namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoLogicManager<TDto, out TCollectionModelDto>
{
    void AddDtoLogic(IDtoEntityHandler<TDto, TCollectionModelDto> logic);

    //TDto RunGet(int id);
    //TDto RunSet(TDto dto);
}