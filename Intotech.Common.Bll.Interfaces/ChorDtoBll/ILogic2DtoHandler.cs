namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface ILogic2DtoHandler<out TDto, TDtoLogic, in TModel, TCollectionModelDto> 
    where TDtoLogic : IAbsDtoLogic<TModel, ILogicBase<TModel>, TDto, TCollectionModelDto>
    where TModel : class
{
    TDto GetData(TModel modelConstraint);
}




/*
public class Logic2Dto<TDto, TLogic, TModel> : ILogic2DtoHandler<TDto, TLogic, TModel>
{
    public TDto GetData(TModel modelConstraint)
    {
        throw new NotImplementedException();
    }
}

public class WeWillLearnIt
{
    private ILogic2DtoHandler<LogicB, string, DedicatedLogic> lol = new Logic2Dto<DedicatedLogic, string, DedicatedLogic>();

}

public abstract class LogicB
{

}

public class DedicatedLogic : LogicB
{
    public Lol<LogicB> asd = new Rotfl<LogicB>();
    public IEnumerable<LogicB> cdfsa = new List<DedicatedLogic>();
}

public class Lol<TDupa>
{

}

public class Rotfl<TTylek> : Lol<TTylek>
{

}*/