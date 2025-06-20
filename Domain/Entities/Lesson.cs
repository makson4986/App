public class Lesson
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public required string Topic { get; set; }

    public int GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}