public class Attendance
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public bool IsPresent { get; set; }

    public Lesson Lesson { get; set; } = null!;
    public User Student { get; set; } = null!;
}