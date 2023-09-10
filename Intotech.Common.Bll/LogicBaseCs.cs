using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Intotech.Common.Bll;

public abstract class LogicBaseCs<TModel> : ILogicBase<TModel>, IDisposable where TModel : ModelBase
{
    protected abstract DbContext GetEfHandle();
    protected static IDbHandle<TModel> DbHandle;
    protected bool isInstance = false;

    public LogicBaseCs()
    {
        if (DbHandle == null)
        {
            DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle);
        }

        isInstance = true;
    }

    protected LogicBaseCs(bool multi = false)
    {
        DbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);
    }

    protected LogicBaseCs(string connectionString)
    {
        DbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle, connectionString);
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate)
    {
        //using (DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle))
        {
            return DbHandle.RawSelect(selectQuery, mapperDelegate);
        }
    }

    public virtual TModel Insert(TModel model)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);

        return DbHandle.Insert(model);

    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);
        {
            List<TModel> result = DbHandle.Select().Where(filter).ToList();

            return result;
        }
    }

    public virtual TModel Update(TModel model)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);

        return DbHandle.Update(model);

    }

    public virtual int Delete(TModel model)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);

        return DbHandle.Delete(model);
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);

        return DbHandle.Delete(tableName, idColumn, id);

    }

    public virtual int Delete(string tableName, string whereClause)
    {
        //DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle);

        return DbHandle.Delete(tableName, whereClause);
    }

    public void Dispose()
    {
        //DbHandle?.Dispose();
    }
}
