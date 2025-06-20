public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<StudentInGroup> Students { get; set; } = new List<StudentInGroup>();

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}