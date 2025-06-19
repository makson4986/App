using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Email), IsUnique = true)]
public class Users
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Role Role { get; set; }

    public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    public ICollection<Attendances> Attendances { get; set; } = new List<Attendances>();
}