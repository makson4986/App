public class Lessons
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public required string Topic { get; set; }

    public Guid GroupId { get; set; }

    public Groups Group { get; set; } = null!;

    public ICollection<Attendances> Attendances { get; set; } = new List<Attendances>();
}