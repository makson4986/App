public class Groups
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid CourseId { get; set; }

    public Courses Course { get; set; } = null!;

    public ICollection<StudentInGroups> Students { get; set; } = new List<StudentInGroups>();

    public ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();
}