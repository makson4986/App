using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Users> Users { get; set; } = null!;
    public DbSet<Courses> Courses { get; set; } = null!;
    public DbSet<Groups> Groups { get; set; } = null!;
    public DbSet<StudentInGroups> StudentInGroups { get; set; } = null!;

    public DbSet<Lessons> Lessons { get; set; } = null!;

    public DbSet<Attendances> Attendances { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=application;Username=postgres;Password=postgres");
    }
}