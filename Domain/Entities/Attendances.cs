public class Attendances
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid StudentId { get; set; }
    public bool IsPresent { get; set; }

    public Lessons Lesson { get; set; } = null!;
    public Users Student { get; set; } = null!;
}