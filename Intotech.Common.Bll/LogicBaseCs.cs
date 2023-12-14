using System.Linq.Expressions;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Intotech.Common.Bll;

public abstract class LogicBaseCs<TModel> : ILogicBase<TModel> where TModel : ModelBase
{
    protected abstract DbContext GetEfHandle();
    protected IDbHandle<TModel> DbHandle;

    public LogicBaseCs()
    {
        
    }

    protected LogicBaseCs(bool multi = false)
    {
        
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
        try
        {
            List<TModel> result = DbHandle.Select(filter).ToList();

            return result;
        }
        catch(Exception ex)
        {
            return default;
        }
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

    public virtual int Delete(Expression<Func<TModel, bool>> selectFilter)
    {
        DbHandleMultiThreading<TModel> dbHandle = new DbHandleMultiThreading<TModel>(GetEfHandle());

        return DbHandle.Delete(selectFilter);
    }
}
