using CourseProvider.Infrastructure.Models;
using CourseProvider.Infrastructure.Services;

namespace CourseProvider.Infrastructure.GraphQL.Queries;

public class CourseQuery(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getAllCourses")]
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }

    [GraphQLName("getCourseById")]
    public async Task<Course> GetCoursesByIdAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    [GraphQLName("getCoursesByCategory")]
    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
    {
        return await _courseService.GetCoursesByCategoryAsync(category);
    }

    [GraphQLName("getAllCategories")]
    public async Task<IEnumerable<string?>> GetAllCategoriesAsync()
    {
        return await _courseService.GetAllCategoriesAsync();
    }

    [GraphQLName("getCoursesBySearch")]
    public async Task<IEnumerable<Course>> GetCoursesBySearchAsync(string searchQuery)
    {
        return await _courseService.GetCoursesBySearchAsync(searchQuery);
    }
}
