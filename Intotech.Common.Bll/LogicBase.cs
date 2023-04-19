using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Intotech.Common.Bll;

public abstract class LogicBase<TModel> : ILogicBase<TModel> where TModel : class
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
        return DbHandle.RawSelect(selectQuery, mapperDelegate);
    }

    public virtual TModel Insert(TModel model)
    {
        return DbHandle.Insert(model);
    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        List<TModel> result = DbHandle.Select().Where(filter).ToList();

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

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        return DbHandle.Delete(tableName, idColumn, id);
    }

    public virtual int Delete(string tableName, string whereClause)
    {
        return DbHandle.Delete(tableName, whereClause);
    }
}
