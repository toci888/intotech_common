using Npgsql;
using System.Linq.Expressions;

namespace Intotech.Common.Database.Interfaces;

public interface IDbHandle<TModel> : IDisposable
{
    IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter);

    IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate);

    TModel Insert(TModel model);

    TModel Update(TModel model);

    int Delete(TModel model);

    int Delete(string tableName, string idColumn, int id);

    int Delete(string tableName, string whereClause);
}