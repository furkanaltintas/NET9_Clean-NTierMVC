using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRepository : IAsyncDisposable
{
    IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new();

    TRepository GetRepository<TEntity, TRepository>()
        where TEntity : BaseEntity, new()
        where TRepository : IEntityRepository<TEntity>;


    Task<int> SaveAsync();
    int Save();
}