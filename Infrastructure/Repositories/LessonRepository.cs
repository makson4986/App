public class LessonRepository : BaseRepository<Lesson>
{
    public LessonRepository(ApplicationDbContext context) : base(context)
    {
    }
}