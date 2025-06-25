using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class GroupRepository : BaseRepository<Group>
{
    public GroupRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Group>> GetAllAsync(Expression<Func<Group, bool>> predicate)
    {
        return await _dbSet.Include(g => g.Course).Where(predicate).ToListAsync();
    }

    public override async Task<Group> AddAsync(Group entity)
    {
        var result = await base.AddAsync(entity);
        await _context.Entry(result).Reference(c => c.Course).LoadAsync();
        return result;
    }
}