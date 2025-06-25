using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Course> Course { get; set; } = null!;
    public DbSet<Group> Group { get; set; } = null!;
    public DbSet<StudentInGroup> StudentInGroup { get; set; } = null!;

    public DbSet<Lesson> Lesson { get; set; } = null!;

    public DbSet<Attendance> Attendance { get; set; } = null!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

}
