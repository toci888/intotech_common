using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Intotech.Common.Database;

public class DbHandleMultiThreading<TModel> : DbHandleManager<TModel>, IDbHandle<TModel>, IDisposable where TModel : ModelBase
{
    protected DbContext DatabaseHandle;
    //protected Func<DbContext> FDatabaseHandle;
    protected NpgsqlConnection Connection;
    private readonly string ConnectionString;
    private readonly object LockObj = new object();

    public DbHandleMultiThreading(DbContext databaseHandle, DbHandleType type) : base(databaseHandle)
    {
        DatabaseHandle = databaseHandle;
    }

    public DbHandleMultiThreading(DbContext databaseHandle) : base(databaseHandle)
    {
        DatabaseHandle = databaseHandle;
    }

    public DbHandleMultiThreading(DbContext databaseHandle, string connectionString) : this(databaseHandle) 
    {
        //FDatabaseHandle = databaseHandle;
        ConnectionString = connectionString;
        DatabaseHandle = databaseHandle;
    }

    public int Delete(TModel model)
    {
        //DbContext context = FDatabaseHandle();
        {
            try
            {
                TModel element = Select(m => m.Id == model.Id).FirstOrDefault();
                if (element == null)
                {
                    return 0;
                }
                DatabaseHandle.Remove(element);// HERE TO FIX
                DatabaseHandle.SaveChanges();
            }
            catch (Exception ex)
            {

            }

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
        //DbContext context = FDatabaseHandle();

        // insert into product (id, ....) 
        EntityEntry entr = DatabaseHandle.Set<TModel>().Add(model);

        DatabaseHandle.SaveChanges();// here

        // DatabaseHandle?.Dispose();

        return (TModel)(entr.Entity);
        
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

    public IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        //DbContext context = FDatabaseHandle();
        IEnumerable<TModel> result = DatabaseHandle.Set<TModel>().Where(filter).ToList();

        //context.Dispose();

        return result;
    }

    public TModel Update(TModel model)
    {
        //DbContext context = FDatabaseHandle();

        DatabaseHandle.Update(model);

        DatabaseHandle.SaveChanges();

        //  DatabaseHandle?.Dispose();

        return model;
        
    }

    public void Dispose()
    {
        //DatabaseHandle?.Dispose();
    }
}