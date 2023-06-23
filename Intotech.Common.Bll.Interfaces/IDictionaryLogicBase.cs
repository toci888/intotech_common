using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces;

public interface IDictionaryLogicBase<TModel> : ILogicBase<TModel> where TModel : DictionaryModelBase
{
    IEnumerable<TModel> GetDictionaryItems(string filter);
}