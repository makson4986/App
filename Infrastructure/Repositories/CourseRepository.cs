using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : BaseRepository<Courses>
{
    public CourseRepository(ApplicationContext context) : base(context)
    {
        
    }
}