using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly ProjectContext _context;

    public CoursesRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetCoursesDetails()
    {
        var data = await _context.Courses
            .Include(e => e.Tutor)
            .Include(e => e.PersonCourses)
            .ThenInclude(e => e.Person).ToListAsync();

        return data;
    }

    public async Task<Course?> GetCourseDetails(int id)
    {
        var data = await _context.Courses
            .Include(e => e.Tutor)
            .Include(e => e.PersonCourses)
            .ThenInclude(e => e.Person).Where(e=>e.Id == id).FirstOrDefaultAsync();

        return data;
    }

    public async Task<int> AddNewCourse(Course course)
    {
        var data = await _context.Courses.AddAsync(course);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<int> UpdateCourse(Course course)
    {
        _context.Courses.Update(course);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteCourse(Course course)
    {
         _context.Remove(course);
         var result = await _context.SaveChangesAsync();
         return result;
    }

    public async Task<int> GetCurrentNumberOfStudents(int courseId)
    {
        return await _context.PersonCourses
            .CountAsync(e => e.CourseId == courseId);
    }

    public async Task<(List<Course> Items, int TotalCount)> GetCoursesPaged(int pageNumber, int pageSize)
    {
        var query = _context.Courses
            .Include(c => c.Tutor)
            .Include(c => c.PersonCourses);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}