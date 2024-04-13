using MinimalAPI.Abstractions;
using MinimalAPI.Entities;

namespace MinimalAPI.Endpoints;

public static class CourseEndpoints
{
    private const string ENDPOINT = "/courses";

    public static void RegisterCourseEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ENDPOINT, (Course course, ICourseRepository repository) =>
        {
            course = repository.Create(course);
            return Results.Created($"{course.CourseId}", course);
        })
            .WithOpenApi();

        endpoints.MapGet(ENDPOINT, (ICourseRepository repository) =>
            Results.Ok(repository.Read()))
            .WithOpenApi();

        endpoints.MapGet("ENDPOINT/{courseId:guid}", (ICourseRepository repository, Guid courseId) =>
        {
            var livro = repository.ReadById(courseId);

            if (livro != null)
                return Results.Ok(livro);
            else
                return Results.NotFound();
        })
            .WithOpenApi();

        endpoints.MapPut("ENDPOINT/{courseId:guid}", (Course course, ICourseRepository repository, Guid courseId) =>
        {
            if (course is null)
                return Results.BadRequest();

            if (courseId != course.CourseId)
                return Results.BadRequest();

            course = repository.Update(course);

            return Results.Ok(course);
        })
            .WithOpenApi();

        endpoints.MapDelete("ENDPOINT/{courseId:guid}", (ICourseRepository repository, Guid courseId) =>
        {
            if (repository.Delete(courseId))
                return Results.Ok();

            return Results.NotFound();
        })
            .WithOpenApi();
    }
}
