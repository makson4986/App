public class StudentInGroup
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }

    public User Student { get; set; } = null!;

    public Group Group { get; set; } = null!;
}