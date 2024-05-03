using Microsoft.EntityFrameworkCore;
using MinimalAPI.Configurations;

namespace MinimalAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigCourse();
    }
}
