using Intotech.Common.Bll.Interfaces;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Seed;

public abstract class SeedBase<TModel> : LogicBaseCs<TModel> where TModel : ModelBase
{
    protected int AccountIdOffset = 0;

    public abstract void Insert();
    public virtual List<TModel> Insert<TPrModel>(List<TPrModel> prevModels)
    {
        return null;
    }

    protected virtual List<TModel> InsertCollection(List<TModel> items)
    {
        bool shouldPopulate = false;

        List <TModel> results = new List<TModel>();

        foreach (TModel item in items)
        {
            Expression<Func<TModel, bool>> SelectWhereCondition = TakeWhereCondition(item);

            TModel? isAlreadyInDb = Select(SelectWhereCondition).FirstOrDefault();
            if (isAlreadyInDb == null)
            {
                shouldPopulate = true;
            }

            if (shouldPopulate)
            {
                results.Add(Insert(item));
            }
        }

        return results;
    }

    public virtual Expression<Func<TModel, bool>> TakeWhereCondition(TModel searchValue)
    {
        return m => true; // TODO WTF ??
    }
}
