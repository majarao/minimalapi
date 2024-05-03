using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI.Entities;

namespace MinimalAPI.Configurations;

public static class CourseConfiguration
{
    public static void ConfigCourse(this ModelBuilder builder)
    {
        EntityTypeBuilder<Course> course = builder.Entity<Course>();

        course.ToTable("Courses");
        course.HasKey(c => c.CourseId);
        course.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(100);
        course.Property(c => c.InstructorName)
            .IsRequired()
            .HasMaxLength(50);
        course.Property(c => c.WorkloadHours)
            .IsRequired();
    }
}
