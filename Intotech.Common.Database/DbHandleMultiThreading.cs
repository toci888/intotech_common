using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using System.Data.SqlClient;
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
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConnectionString;
        connection.Open();

        SqlCommand command = connection.CreateCommand();
        command.CommandText = $"delete from {tableName} where {idColumn} = {id}";

        int result = command.ExecuteNonQuery();

        connection.Close();
        command.Dispose();

        return result;
    }

    public virtual int Delete(string tableName, string whereClause)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConnectionString;
        connection.Open();

        SqlCommand command = connection.CreateCommand();

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
            return default;
        }


        return (TModel)(entr.Entity);
    }

    public virtual IEnumerable<TModel> RawSelect(string selectQuery, Func<SqlDataReader, TModel> mapperDelegate)
    {
        SqlConnection connection = new SqlConnection();

        connection.ConnectionString = ConnectionString;
        connection.Open();

        SqlCommand command = connection.CreateCommand();

        command.CommandText = selectQuery;

        SqlDataReader reader = command.ExecuteReader();

        List<TModel> result = new List<TModel>();

        while (reader.Read())
        {
            result.Add(mapperDelegate(reader));
        }

        connection.Close();
        command.Dispose();

        return result;
    }

    public IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
    {
        try
        {
            //DbContext context = FDatabaseHandle();
            IEnumerable<TModel> result = DatabaseHandle.Set<TModel>().Where(filter).ToList();
            //context.Dispose();

            return result;
        }
        catch (Exception ex)
        {
            return new List<TModel>();
        }


    }

    public TModel Update(TModel model)
    {
        //DbContext context = FDatabaseHandle();

        DatabaseHandle.Update(model);

        DatabaseHandle.SaveChanges();

        //  DatabaseHandle?.Dispose();

        return model;
        
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
            DatabaseHandle.Remove(elements); // TODO check if deleted ? 
        }

        DatabaseHandle.SaveChanges();

        return elements.Count(); // line 44
    }

    public void Dispose()
    {
        //DatabaseHandle?.Dispose();
    }
}