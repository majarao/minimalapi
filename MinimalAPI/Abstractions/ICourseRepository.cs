using MinimalAPI.Entities;

namespace MinimalAPI.Abstractions;

public interface ICourseRepository
{
    Course Create(Course course);
    IQueryable<Course>? Read();
    Course? ReadById(Guid courseId);
    Course Update(Course course);
    bool Delete(Guid courseId);
}
