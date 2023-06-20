using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Bll.Dictionaries;

public abstract class DictionaryLogicBase<TDictionaryModel> : LogicBase<TDictionaryModel> where TDictionaryModel : DictionaryModelBase
{
    public virtual IEnumerable<TDictionaryModel> GetDictionaryItems(string filter)
    {
        return Select(m => m.Name.StartsWith(filter));
    }
}