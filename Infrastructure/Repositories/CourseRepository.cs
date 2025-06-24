using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : BaseRepository<Course>
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {

    }

    public override async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _dbSet.Include(c => c.CreatedBy).ToArrayAsync();
    }

    public override async Task<Course> AddAsync(Course entity)
    {
        var result = await base.AddAsync(entity);
        await _context.Entry(result).Reference(c => c.CreatedBy).LoadAsync();
        return result;
    }

    public override async Task<Course?> GetAsync(int id)
    {
        return await _dbSet
            .Include(c => c.CreatedBy)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}