namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoEntityHandler<TDto>
{
    TDto GetEntity(TDto masterEntity);
}