using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract;

public interface IEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<IList<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool enableTracking = false);

    Task<IList<TEntity>> GetAllByPagingAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool enableTracking = false, int currentPage = 1, int pageSize = 3);

    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = false);

    Task<TEntity> GetAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false);

    IQueryable<TEntity> Find(
        Expression<Func<TEntity, bool>> predicate, bool enableTracking = false);

    Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate = null);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null);

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IList<TEntity> entities);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task HardDeleteAsync(TEntity entity);

    Task HardDeleteRangeAsync(IList<TEntity> entities);
}