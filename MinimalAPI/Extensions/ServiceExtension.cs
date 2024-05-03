using Microsoft.EntityFrameworkCore;
using MinimalAPI.Abstractions;
using MinimalAPI.Context;
using MinimalAPI.Repositories;

namespace MinimalAPI.Extensions;

public static class ServiceExtension
{
    public static void AddDbContext(this IServiceCollection services, ConfigurationManager configurationManager) =>
        services.AddDbContext<AppDbContext>(option => option
            .UseSqlServer(configurationManager.GetConnectionString("DefaultConnection")));

    public static void AddServices(this IServiceCollection services) =>
        services.AddScoped<ICourseRepository, CourseRepository>();
}
