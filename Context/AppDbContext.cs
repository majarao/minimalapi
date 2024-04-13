using Microsoft.EntityFrameworkCore;
using MinimalAPI.Configurations;

namespace MinimalAPI.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigCourse();
    }
}
