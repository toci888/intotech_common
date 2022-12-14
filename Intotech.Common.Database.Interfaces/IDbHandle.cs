namespace Intotech.Common.Database.Interfaces;

public interface IDbHandle<TModel> : IDisposable
{
    IQueryable<TModel> Select();

    TModel Insert(TModel model);

    TModel Update(TModel model);

    int Delete(TModel model);
}