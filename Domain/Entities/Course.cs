using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [Column(TypeName = "TEXT")]
    public required string Description { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}