using Intotech.Common.Bll;

namespace Intotech.Common.Tests;

public abstract class SeedBase<TModel> : LogicBase<TModel> where TModel : class
{
    public abstract void Insert();

    protected virtual void InsertCollection(List<TModel> items)
    {
        foreach (TModel item in items)
        {
            Insert(item);
        }
    }
}
