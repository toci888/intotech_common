using Npgsql;

namespace Intotech.Common.Database.Interfaces;

public interface IDrToTModelMapper<out TModel> where TModel : class
{
    TModel MapFromReader(NpgsqlDataReader dataReader);
}