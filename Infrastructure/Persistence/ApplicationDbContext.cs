using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Course> Course { get; set; } = null!;
    public DbSet<Group> Group { get; set; } = null!;
    public DbSet<StudentInGroup> StudentInGroup { get; set; } = null!;

    public DbSet<Lesson> Lesson { get; set; } = null!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);

    //     builder.Entity<IdentityUser>(entity =>
    //     {
    //         entity.ToTable(name: "User");
    //     });

    //     builder.Entity<IdentityRole>(entity =>
    //     {
    //         entity.ToTable(name: "Roles");
    //     });

    //     builder.Entity<IdentityUserRole<string>>(entity =>
    //     {
    //         entity.ToTable("UserRoles");
    //     });

    //     builder.Entity<IdentityUserClaim<string>>(entity =>
    //     {
    //         entity.ToTable("UserClaims");
    //     });

    //     builder.Entity<IdentityUserLogin<string>>(entity =>
    //     {
    //         entity.ToTable("UserLogins");
    //     });

    //     builder.Entity<IdentityRoleClaim<string>>(entity =>
    //     {
    //         entity.ToTable("RoleClaims");
    //     });

    //     builder.Entity<IdentityUserToken<string>>(entity =>
    //     {
    //         entity.ToTable("UserTokens");
    //     });
    // }
}
