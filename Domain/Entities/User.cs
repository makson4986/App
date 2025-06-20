using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Role Role { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}