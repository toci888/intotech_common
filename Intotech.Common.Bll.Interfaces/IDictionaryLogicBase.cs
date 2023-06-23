using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces;

public interface IDictionaryLogicBase<TModel> : ILogicBase<TModel> where TModel : class
{
    IEnumerable<TModel> GetDictionaryItems(Expression<Func<TModel, bool>> filter);
}