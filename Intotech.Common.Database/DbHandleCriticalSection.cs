using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using System.Linq.Expressions;

namespace Intotech.Common.Database;

public class DbHandleCriticalSection<TModel> : IDbHandle<TModel> where TModel : ModelBase
{
    protected DbContext DatabaseHandle;
    private readonly string ConnectionString;

    public DbHandleCriticalSection(DbContext databaseHandle, DbHandleType type) : this(databaseHandle)
    {

    }

    public DbHandleCriticalSection(DbContext databaseHandle, bool sc) : this(databaseHandle)
    {
    }

    public DbHandleCriticalSection(DbContext databaseHandle)
    {
        DatabaseHandle = databaseHandle;
    }

    public DbHandleCriticalSection(DbContext databaseHandle, string connectionString) : this(databaseHandle)
    {
        ConnectionString = connectionString;
    }

    public virtual int Delete(TModel model)
    {
        TModel? element = Select(m => m.Id == model.Id).FirstOrDefault();
        if (element == null)
        {
            return 0;
        }

        DatabaseHandle.Remove(element); // TODO check if deleted ? 
        DatabaseHandle.SaveChanges();

        return 1; // line 44
    }

    public virtual int Delete(Expression<Func<TModel, bool>> selectFilter)
    {
        List<TModel> elements = Select(selectFilter).ToList();
        if (elements == null)
        {
            return 0;
        }

        foreach (TModel element in elements)
        {
            DatabaseHandle.Remove(element); // TODO check if deleted ? 
        }

        DatabaseHandle.SaveChanges();

        return elements.Count(); // line 44
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        connection.ConnectionString = ConnectionString;
        connection.Open();

        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = $"delete from {tableName} where {idColumn} = {id}";

        int result = command.ExecuteNonQuery();

        connection.Close();
        command.Dispose();

        return result;
    }

    public virtual int Delete(string tableName, string whereClause)
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        connection.ConnectionString = ConnectionString;
        connection.Open();

        NpgsqlCommand command = connection.CreateCommand();

        command.CommandText = $"delete from {tableName} where {whereClause}";

        int result = command.ExecuteNonQuery();

        connection.Close();
        command.Dispose();

        return result;
    }

    public virtual TModel Insert(TModel model)
    {
        EntityEntry entr = DatabaseHandle.Set<TModel>().Add(model);

        try
        {
            DatabaseHandle.SaveChanges();
        }
        catch (Exception ex)
        {

        }

        return (TModel)(entr.Entity);
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate)
    {
        NpgsqlConnection connection = new NpgsqlConnection();

        connection.ConnectionString = ConnectionString;
        connection.Open();

        NpgsqlCommand command = connection.CreateCommand();

        command.CommandText = selectQuery;

        NpgsqlDataReader reader = command.ExecuteReader();

        List<TModel> result = new List<TModel>();

        while (reader.Read())
        {
            result.Add(mapperDelegate(reader));
        }

        connection.Close();
        command.Dispose();

        return result;
    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        IEnumerable<TModel> result = DatabaseHandle.Set<TModel>().Where(filter).ToList();

        return result;
    }

    public virtual TModel Update(TModel model)
    {
        DatabaseHandle.Update(model);
        DatabaseHandle.SaveChanges();

        return model;
    }
}