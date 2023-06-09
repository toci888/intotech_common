using System.Linq.Expressions;

namespace Intotech.Common.Bll.Seed;

public abstract class SeedBase<TModel> : LogicBase<TModel> where TModel : class
{
    protected int AccountIdOffset = 0;

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

    public virtual Expression<Func<TModel, bool>> TakeWhereCondition(TModel searchValue)
    {
        return m => true;
    }
}
