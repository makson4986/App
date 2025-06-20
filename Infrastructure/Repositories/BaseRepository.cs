using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetAsync(int id) => await _dbSet.FindAsync(id);
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToArrayAsync();

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}