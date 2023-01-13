using Npgsql;

namespace Intotech.Common.Database.Interfaces;

public interface IDrToTModelMapper<TModel> where TModel : class
{
    TModel MapFromReader(NpgsqlDataReader dataReader);
}