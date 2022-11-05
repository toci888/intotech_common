namespace Intotech.Common.Microservices.Interfaces;

public interface IApiControllerBase<TLogic, TModel>
{
    public TModel Create(TModel model);
    public IEnumerable<TModel> Get();
    public TModel Update(TModel model);
    public int Delete(TModel model);
}