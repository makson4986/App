public class Attendances
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public bool IsPresent { get; set; }

    public Lessons Lesson { get; set; } = null!;
    public Users Student { get; set; } = null!;
}