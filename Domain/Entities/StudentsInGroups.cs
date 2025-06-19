public class StudentInGroups
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }

    public Users Student { get; set; } = null!;

    public Groups Group { get; set; } = null!;
}