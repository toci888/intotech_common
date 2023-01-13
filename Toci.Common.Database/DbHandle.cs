using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Intotech.Common.Database;

public class DbHandle<TModel> : IDbHandle<TModel> where TModel : class
{
    protected DbContext DatabaseHandle;
    protected NpgsqlConnection Connection;
    private readonly string ConnectionString;
    private readonly object LockObj = new object();

    public DbHandle(Func<DbContext> databaseHandle)
    {
        DatabaseHandle = databaseHandle();
    }

    public DbHandle(Func<DbContext> databaseHandle, string connectionString)
    {
        DatabaseHandle = databaseHandle();
        ConnectionString = connectionString;
    }

    public int Delete(TModel model)
    {
        lock (LockObj)
        {
            DatabaseHandle.Remove(model);

            DatabaseHandle.SaveChanges();

            // DatabaseHandle?.Dispose();

            return 1;
        }
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        Connection = new NpgsqlConnection();
        Connection.ConnectionString = ConnectionString;
        Connection.Open();

        NpgsqlCommand command = Connection.CreateCommand();
        command.CommandText = "delete from Accountscollocations where " + idColumn + " = " + id;

        return command.ExecuteNonQuery();
    }

    public virtual int Delete(string tableName, string whereClause)
    {
        Connection = new NpgsqlConnection();
        Connection.ConnectionString = ConnectionString;
        Connection.Open();

        NpgsqlCommand command = Connection.CreateCommand();
        command.CommandText = "delete from Accountscollocations where " + whereClause;

        return command.ExecuteNonQuery();
    }

    public TModel Insert(TModel model)
    {
        lock (LockObj)
        {
            // insert into product (id, ....)
            EntityEntry entr = DatabaseHandle.Set<TModel>().Add(model);

            DatabaseHandle.SaveChanges();

            // DatabaseHandle?.Dispose();

            return (TModel)(entr.Entity);
        }
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<NpgsqlDataReader, TModel> mapperDelegate)
    {
        Connection = new NpgsqlConnection();
        Connection.ConnectionString = ConnectionString;
        Connection.Open();

        NpgsqlCommand command = Connection.CreateCommand();
        command.CommandText = selectQuery;

        NpgsqlDataReader reader = command.ExecuteReader();

        List<TModel> result = new List<TModel>();

        while (reader.Read())
        {
            result.Add(mapperDelegate(reader));
        }

        return result;
    }

    public IQueryable<TModel> Select()
    {
        lock (LockObj)
        {
            IQueryable<TModel> result = DatabaseHandle.Set<TModel>().AsQueryable().AsNoTracking();

            //DatabaseHandle.Dispose();

            return result;
        }
    }

    public TModel Update(TModel model)
    {
        lock (LockObj)
        {
            DatabaseHandle.Update(model);

            DatabaseHandle.SaveChanges();

            //  DatabaseHandle?.Dispose();

            return model;
        }
    }

    public void Dispose()
    {
        DatabaseHandle?.Dispose();
    }
}