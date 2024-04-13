namespace MinimalAPI.Entities;

public class Course
{
    public Guid CourseId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string InstructorName { get; set; } = string.Empty;
    public int WorkloadHours { get; set; }
}
