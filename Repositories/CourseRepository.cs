using MinimalAPI.Abstractions;
using MinimalAPI.Context;
using MinimalAPI.Entities;

namespace MinimalAPI.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public Course Create(Course course)
    {
        AppDbContext.Set<Course>().Add(course);
        AppDbContext.SaveChanges();
        return course;
    }

    public IQueryable<Course>? Read() => AppDbContext.Set<Course>();

    public Course? ReadById(Guid courseId) => AppDbContext.Set<Course>().FirstOrDefault(c => c.CourseId == courseId);

    public Course Update(Course course)
    {
        AppDbContext.Set<Course>().Update(course);
        AppDbContext.SaveChanges();
        return course;
    }

    public bool Delete(Guid courseId)
    {
        Course? course = ReadById(courseId);
        if (course != null)
        {
            AppDbContext.Set<Course>().Remove(course);
            AppDbContext.SaveChanges();
            return true;
        }

        return false;
    }
}
