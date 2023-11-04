using Npgsql;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces;

public interface ILogicBase<TModel> where TModel : ModelBase
{
    IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter);

    IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate);

    TModel Insert(TModel model);

    TModel Update(TModel model);

    int Delete(TModel model);

    int Delete(string tableName, string idColumn, int id);

    int Delete(string tableName, string whereClause);

    int Delete(Expression<Func<TModel, bool>> selectFilter);
}