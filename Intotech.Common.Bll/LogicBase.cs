using System.Data.SqlClient;
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
    protected IErrorLogger ErrorLogger;

    public LogicBase(IErrorLogger errorLogger)
    {
        DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle(), errorLogger);
    }

    protected LogicBase(bool multi = false)
    {
        DbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());
    }

    protected LogicBase(string connectionString)
    {
        DbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle(), connectionString);
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<SqlDataReader, TModel> mapperDelegate)
    {
        using (DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle()))
        {
            return DbHandle.RawSelect(selectQuery, mapperDelegate);
        }
    }

    public virtual TModel Insert(TModel model)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Insert(model);

    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());
        {
            List<TModel> result = dbHandle.Select(filter).ToList();

            return result;
        }
    }

    public virtual TModel Update(TModel model)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Update(model);

    }

    public virtual int Delete(TModel model)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Delete(model);
    }

    public virtual int Delete(Expression<Func<TModel, bool>> selectFilter)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Delete(selectFilter);
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Delete(tableName, idColumn, id);

    }

    public virtual int Delete(string tableName, string whereClause)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Delete(tableName, whereClause);
    }

    public void Dispose()
    {
        //DbHandle?.Dispose();
    }
}
