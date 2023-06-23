using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;

namespace Intotech.Common.Bll.Dictionaries;

public abstract class DictionaryLogicBase<TDictionaryModel> : LogicBase<TDictionaryModel> where TDictionaryModel : DictionaryModelBase
{
    public virtual IEnumerable<TDictionaryModel> GetDictionaryItems(string filter)
    {
        return Select(m => m.Name.ToLower().StartsWith(filter));
    }
}