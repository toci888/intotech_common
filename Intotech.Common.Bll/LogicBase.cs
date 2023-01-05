using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Bll;

public abstract class LogicBase<TModel> : ILogicBase<TModel> where TModel : class
{
    protected abstract DbContext GetEfHandle();
    protected IDbHandle<TModel> DbHandle;

    public LogicBase()
    {
        DbHandle = new DbHandle<TModel>(GetEfHandle);
    }


    public virtual TModel Insert(TModel model)
    {
        return DbHandle.Insert(model);
    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter) // model => model.id == ??
    {
        List<TModel> result = DbHandle.Select().Where(filter).ToList();

        //  DbHandle.Dispose();

        return result;

    }

    public virtual TModel Update(TModel model)
    {
        return DbHandle.Update(model);
    }

    public virtual int Delete(TModel model)
    {
        return DbHandle.Delete(model);
    }

    //public abstract int DeleteByColumnId(string column, int whereId);
}
