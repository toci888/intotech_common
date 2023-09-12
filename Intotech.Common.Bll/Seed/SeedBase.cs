using Intotech.Common.Bll.Interfaces;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Seed;

public abstract class SeedBase<TModel> : LogicBaseCs<TModel>, IDisposable where TModel : ModelBase
{
    protected int AccountIdOffset = 0;

    public abstract void Insert();

    public SeedBase()
    {
        //DbHandle = new DbHandleCriticalSectionIWC<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");

    }

    protected virtual void InsertCollection(List<TModel> items)
    {
        bool shouldPopulate = false;
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
                Insert(item);
            }
        }
    }

    public virtual Expression<Func<TModel, bool>> TakeWhereCondition(TModel searchValue)
    {
        return m => true;
    }

    //public void Dispose()
    //{
    //    //DbHandle?.Dispose();
    //}
}
