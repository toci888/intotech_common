using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces;

public interface ILogicBase<TModel> where TModel : class
{
    IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter);

    TModel Insert(TModel model);

    TModel Update(TModel model);

    int Delete(TModel model);
}