using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Intotech.Common.Database;

public class DbHandle<TModel> : IDbHandle<TModel> where TModel : class
{
    protected DbContext DatabaseHandle;
    private static object LockObj = new object();

    public DbHandle(Func<DbContext> databaseHandle)
    {
        DatabaseHandle = databaseHandle();
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