using Intotech.Common.Bll.Interfaces.ChorDtoBll;

namespace Intotech.Common.Bll.ChorDtoBll;

public class DtoLogicManager<TDto> : IDtoLogicManager<TDto> where TDto : new()
{
    protected List<IDtoEntityHandler<TDto>> Handlers = new List<IDtoEntityHandler<TDto>>();


    public virtual void AddDtoLogic(IDtoEntityHandler<TDto> logic)
    {
        Handlers.Add(logic);
    }

    public virtual TDto RunGet(int id)
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
    }
}