using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Intotech.Common.Bll;

public abstract class LogicBase<TModel> : ILogicBase<TModel>, IDisposable where TModel : ModelBase
{
    protected abstract DbContext GetEfHandle();
    protected IDbHandle<TModel> DbHandle;

    protected LogicBase()
    {
        DbHandle = new DbHandle<TModel>(GetEfHandle);
    }

    protected LogicBase(string connectionString)
    {
        DbHandle = new DbHandle<TModel>(GetEfHandle, connectionString);
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate)
    {
        using (DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle))
        {
            return DbHandle.RawSelect(selectQuery, mapperDelegate);
        }
    }

    public virtual TModel Insert(TModel model)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);

        return DbHandle.Insert(model);

    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);
        {
            List<TModel> result = dbHandle.Select().Where(filter).ToList();

            return result;
        }
    }

    public virtual TModel Update(TModel model)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);

        return DbHandle.Update(model);

    }

    public virtual int Delete(TModel model)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);

        return DbHandle.Delete(model);
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);

        return DbHandle.Delete(tableName, idColumn, id);

    }

    public virtual int Delete(string tableName, string whereClause)
    {
        DbHandle<TModel> dbHandle = new DbHandle<TModel>(GetEfHandle);

        return DbHandle.Delete(tableName, whereClause);
    }

    public void Dispose()
    {
        //DbHandle?.Dispose();
    }
}
