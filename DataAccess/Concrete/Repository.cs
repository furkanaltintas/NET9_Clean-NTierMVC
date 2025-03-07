using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ValueTask DisposeAsync() => _context.DisposeAsync();

    public int Save() => _context.SaveChanges();

    public Task<int> SaveAsync() => _context.SaveChangesAsync();

    IEntityRepository<TEntity> IRepository.GetRepository<TEntity>() =>
        new EfEntityRepositoryBase<TEntity>(_context);

    TRepository IRepository.GetRepository<TEntity, TRepository>() =>
        (TRepository)Activator.CreateInstance(typeof(TRepository), _context);
}