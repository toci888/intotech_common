using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Dictionaries;

public abstract class DictionaryLogicBase<TDictionaryModel> : LogicBase<TDictionaryModel> where TDictionaryModel : DictionaryModelBase
{
    public virtual IEnumerable<TDictionaryModel> GetDictionaryItems(Expression<Func<TDictionaryModel, bool>> filter)
    {
        return Select(filter);
    }
}