using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Bll.Dictionaries;

public abstract class DictionaryLogicBase<TDictionaryModel> : LogicBase<TDictionaryModel> where TDictionaryModel : DictionaryModelBase
{

}