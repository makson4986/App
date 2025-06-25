using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : BaseRepository<Course>
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {

    }
}