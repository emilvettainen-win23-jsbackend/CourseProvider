using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Factories;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Services;


public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest request);

    Task<Course> GetCourseByIdAsync(string id);

    Task<IEnumerable<Course>> GetCoursesByIdsAsync(IEnumerable<string> ids);

    Task<IEnumerable<Course>> GetCoursesAsync();

    Task<IEnumerable<string?>> GetAllCategoriesAsync();

    Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category);

    Task<IEnumerable<Course>> GetCoursesBySearchAsync(string searchQuery);

    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);

    Task<bool> DeleteCourseAsync(string id);
}


public class CourseService(IDbContextFactory<CourseDataContext> dbContextFactory) : ICourseService
{
    private readonly IDbContextFactory<CourseDataContext> _dbContextFactory = dbContextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        //if(await context.Courses.AnyAsync(x => x.CourseTitle == request.CourseTitle))
        //{
        //    return null!;
        //}
        var courseEntity = CourseFactory.Create(request);
        context.Courses.Add(courseEntity);
        await context.SaveChangesAsync();
        return CourseFactory.Read(courseEntity);
    }

    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        return courseEntity == null ? null! : CourseFactory.Read(courseEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var courseEntities = await context.Courses.ToListAsync();
        return courseEntities.Select(CourseFactory.Read);
    }

    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var existingCourse = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (existingCourse == null)
        {
            return null!;
        }
        var updatedCourseEntity = CourseFactory.Update(request);
        updatedCourseEntity.Id = existingCourse.Id;
        context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);
        await context.SaveChangesAsync();
        return CourseFactory.Read(updatedCourseEntity);
    }

    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (courseEntity == null)
        {
            return false;
        }
        context.Courses.Remove(courseEntity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var coursesByCategory = await context.Courses.Where(c => c.Category == category).ToListAsync();
        return coursesByCategory.Select(CourseFactory.Read);
    }

    public async Task<IEnumerable<string?>> GetAllCategoriesAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();
        return await context.Courses
            .Select(c => c.Category)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesBySearchAsync(string searchQuery)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var searchCoursesBySearch = await context.Courses.
            Where(x => x.CourseTitle.ToLower().Contains(searchQuery.ToLower()) || x.Author.FullName.ToLower().Contains(searchQuery.ToLower())).ToListAsync();
        return searchCoursesBySearch.Select(CourseFactory.Read);
    }

    public async Task<IEnumerable<Course>> GetCoursesByIdsAsync(IEnumerable<string> ids)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var courses = await context.Courses.Where(x => ids.Contains(x.Id)).ToListAsync();
        return courses.Select(CourseFactory.Read);
    }
}
