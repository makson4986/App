using Microsoft.AspNetCore.Identity;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<CourseRepository>();
        services.AddScoped<GroupRepository>();
        services.AddScoped<StudentInGroupRepository>();
        services.AddScoped<AuthRepository>();
        services.AddScoped<LessonRepository>();
        services.AddScoped<AttendanceRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<CourseService>();
        services.AddScoped<GroupsService>();
        services.AddScoped<AuthService>();
        services.AddScoped<StudentInGroupService>();
        services.AddScoped<LessonsService>();
        services.AddScoped<AttendanceService>();
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        return services;
    }
}
