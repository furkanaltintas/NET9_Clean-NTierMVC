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

    IEntityRepository<TEntity> IRepository.GetRepository<TEntity>() =>
        new EfEntityRepositoryBase<TEntity>(_context);

    TRepository IRepository.GetRepository<TEntity, TRepository>() =>
        (TRepository)Activator.CreateInstance(typeof(TRepository), _context);
}