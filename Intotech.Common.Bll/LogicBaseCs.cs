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
    protected IDbHandle<TModel> DbHandle;
    protected string ConnectionString = "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka";

    public LogicBaseCs()
    {
        
    }

    protected LogicBaseCs(bool multi = false)
    {
        
    }

    protected LogicBaseCs(string connectionString)
    {
        
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle, ConnectionString))
        {
            return DbHandle.RawSelect(selectQuery, mapperDelegate);
        }
    }

    public virtual TModel Insert(TModel model)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            return DbHandle.Insert(model);
        }
    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            List<TModel> result = DbHandle.Select(filter).ToList();

            return result;
        }
    }

    public virtual TModel Update(TModel model)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            return DbHandle.Update(model);
        }
    }

    public virtual int Delete(TModel model)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            return DbHandle.Delete(model);
        }
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        //using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            return DbHandle.Delete(tableName, idColumn, id);
        }
    }

    public virtual int Delete(string tableName, string whereClause)
    {
       /// using (DbHandle = new DbHandleCriticalSection<TModel>(GetEfHandle))
        {
            return DbHandle.Delete(tableName, whereClause);
        }
    }

    public void Dispose()
    {
        DbHandle?.Dispose();
    }
}
