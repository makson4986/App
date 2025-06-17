public class StudentInGroups
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid GroupId { get; set; }

    public Users Student { get; set; } = null!;

    public Groups Group { get; set; } = null!;
}