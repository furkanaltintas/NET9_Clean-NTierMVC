using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    private readonly DbContext _context;

    public EfEntityRepositoryBase(DbContext context) { _context = context; }

    private DbSet<TEntity> Table { get => _context.Set<TEntity>(); }


    public async Task AddAsync(TEntity entity) => await Table.AddAsync(entity);

    public async Task AddRangeAsync(IList<TEntity> entities) => await Table.AddRangeAsync(entities);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var query = Table.AsNoTracking();

        if (predicate is not null) query = query.Where(predicate);
        return await query.AnyAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var query = Table.AsNoTracking();

        if (predicate is not null) query = query.Where(predicate);
        return await query.CountAsync();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool enableTracking = false)
    {
        var query = enableTracking ? Table : Table.AsNoTracking();
        return query.Where(predicate);
    }

    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<TEntity> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orderBy is not null) queryable = orderBy(queryable);
        return await queryable.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IList<TEntity>> GetAllByPagingAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<TEntity> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orderBy is not null) return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);
        return await queryable.ToListAsync().ConfigureAwait(false);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<TEntity> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> GetAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<TEntity> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync();
    }

    public async Task HardDeleteAsync(TEntity entity)
    {
        var local = Table.Local.FirstOrDefault(t => t.Id == entity.Id);
        if (local != null) Table.Entry(local).State = EntityState.Detached; // Önce eski entity takibini bırak

        Table.Remove(entity);

        //await Task.Run(() => Table.Remove(entity));
    }

    public async Task HardDeleteRangeAsync(IList<TEntity> entities) => await Task.Run(() => Table.RemoveRange(entities));

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var local = Table.Local.FirstOrDefault(t => t.Id == entity.Id);
        if (local != null) Table.Entry(local).State = EntityState.Detached; // Önce eski entity takibini bırak

        Table.Attach(entity);
        Table.Entry(entity).State = EntityState.Modified;
        return entity;

        //await Task.Run(() => Table.Update(entity));
        //return entity;
    }
}