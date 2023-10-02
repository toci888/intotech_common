using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Intotech.Common.Database;

public class DbHandleCriticalSection<TModel> : IDbHandle<TModel>, IDisposable where TModel : ModelBase
{
    protected Func<DbContext> FDatabaseHandle;
    protected NpgsqlConnection Connection;
    private readonly string ConnectionString = "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka"; // TODO SYF
    private readonly object LockObj = new object();

    public DbHandleCriticalSection(Func<DbContext> databaseHandle, DbHandleType type) : this(databaseHandle)
    {
        
    }

    public DbHandleCriticalSection(Func<DbContext> databaseHandle, bool sc) : this(databaseHandle)
    {
    }

    public DbHandleCriticalSection(Func<DbContext> databaseHandle)
    {
        FDatabaseHandle = databaseHandle;
    }

    public DbHandleCriticalSection(Func<DbContext> databaseHandle, string connectionString)
    {
        FDatabaseHandle = databaseHandle; 
        ConnectionString = "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka"; //connectionString
    }

    public virtual int Delete(TModel model)
    {
        lock (LockObj)
        {
            using (DbContext context = FDatabaseHandle())
            {
                try
                {
                    TModel element = Select(m => m.Id == model.Id).FirstOrDefault();
                    if (element == null)
                    {
                        return 0;
                    }
                    context.Remove(element);// HERE TO FIX
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }

                // DatabaseHandle?.Dispose();

                return 1;
            }
        }
    }

    public virtual int Delete(string tableName, string idColumn, int id)
    {
        Connection = new NpgsqlConnection();
        Connection.ConnectionString = ConnectionString;
        Connection.Open();

        NpgsqlCommand command = Connection.CreateCommand();
        command.CommandText = "delete from Accountscollocations where " + idColumn + " = " + id;

        int result = command.ExecuteNonQuery();

        Connection.Close();
        command.Dispose();

        return result;
    }

    public virtual int Delete(string tableName, string whereClause)
    {
        Connection = new NpgsqlConnection();
        Connection.ConnectionString = ConnectionString;
        Connection.Open();

        NpgsqlCommand command = Connection.CreateCommand();
        command.CommandText = "delete from Accountscollocations where " + whereClause;

        int result = command.ExecuteNonQuery();

        Connection.Close();
        command.Dispose();

        return result;
    }

    public virtual TModel Insert(TModel model)
    {
        //

        // insert into product (id, ....) 
        using (DbContext context = FDatabaseHandle())
        {
            EntityEntry entr = context.Set<TModel>().Add(model);

            context.SaveChanges();// here

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

        Connection.Close();
        command.Dispose();

        return result;
    }

    public virtual IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        using (DbContext context = FDatabaseHandle())
        {
            IEnumerable<TModel> result = context.Set<TModel>().Where(filter).ToList();

            //context.Dispose();

            return result;
        }
    }

    public virtual TModel Update(TModel model)
    {
        //DbContext context = FDatabaseHandle();
        //DbContext context = FDatabaseHandle();
        using (DbContext context = FDatabaseHandle())
        {
            context.Update(model);

            context.SaveChanges();

            //  DatabaseHandle?.Dispose();

            return model;
        }

    }

    public void Dispose()
    {
        //DatabaseHandle?.Dispose();
    }
}