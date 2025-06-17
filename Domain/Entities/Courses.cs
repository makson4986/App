using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Courses
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    [Column(TypeName = "TEXT")]
    public required string Description { get; set; }
    public Guid CreatedById { get; set; }
    public Users CreatedBy { get; set; } = null!;

    public ICollection<Groups> Groups { get; set; } = new List<Groups>();
}