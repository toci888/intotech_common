using Intotech.Common.Bll;
using System.Linq.Expressions;

namespace Intotech.Common.Tests;

public abstract class SeedBase<TModel> : LogicBase<TModel> where TModel : class
{
    public abstract void Insert();

    protected virtual void InsertCollection(List<TModel> items)
    {
        foreach (TModel item in items)
        {
            Expression<Func<TModel, bool>> SelectWhereCondition = TakeWhereCondition(item);

            if (Select(SelectWhereCondition).FirstOrDefault() == null)
            {
                Insert(item);
            }
        }
    }

    public abstract Expression<Func<TModel, bool>> TakeWhereCondition(TModel searchValue);
}
