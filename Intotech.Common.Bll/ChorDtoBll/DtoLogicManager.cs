using Intotech.Common.Bll.Interfaces.ChorDtoBll;

namespace Intotech.Common.Bll.ChorDtoBll;

public class DtoLogicManager<TDto, TCollectionModelDto> : IDtoLogicManager<TDto, TCollectionModelDto> 
    where TDto : new()
{
    protected List<IDtoEntityHandler<TDto, TCollectionModelDto>> Handlers = new List<IDtoEntityHandler<TDto, TCollectionModelDto>>();


    public virtual void AddDtoLogic(IDtoEntityHandler<TDto, TCollectionModelDto> logic)
    {
        Handlers.Add(logic);
    }

    public virtual TDto GetData(int id)
    {
        //new AccountDtoLogic

        return new TDto();
    }

    /*public virtual TDto RunGet(int id)
    {
        TDto dto = new TDto();

        foreach (IDtoEntityHandler<TDto> handler in Handlers)
        {
            dto = handler.GetEntity(dto);
        }

        return dto;
    }

    public virtual TDto RunSet(TDto dto)
    {
        foreach(IDtoEntityHandler<TDto> handler in Handlers)
        {
            dto = handler.SetEntity(dto);
        }

        return dto;
    }*/
}