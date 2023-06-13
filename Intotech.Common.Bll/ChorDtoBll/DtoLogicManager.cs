using Intotech.Common.Bll.Interfaces.ChorDtoBll;

namespace Intotech.Common.Bll.ChorDtoBll;

public class DtoLogicManager<TDto> : IDtoLogicManager<TDto>
{
    protected List<IDtoEntityHandler<TDto>> Handlers = new List<IDtoEntityHandler<TDto>>();


    public virtual void AddDtoLogic(IDtoEntityHandler<TDto> logic)
    {
        Handlers.Add(logic);
    }

    public virtual TDto RunGet()
    {
        foreach (IDtoEntityHandler<TDto> handler in Handlers)
        {
            //handler.GetEntity();
        }

        return default(TDto);
    }

    public TDto RunSet()
    {
        throw new NotImplementedException();
    }
}