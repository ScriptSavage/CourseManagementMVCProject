using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonCoursesRepository : IPersonCoursesRepository
{
    private readonly ProjectContext _context;

    public PersonCoursesRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task AddPersonCourse(PersonCourses personCourse)
    {
        _context.PersonCourses.Add(personCourse);
        await _context.SaveChangesAsync();
    }

    public async Task<PersonCourses?> GetPersonCourse(int personId, int courseId)
    {
        return await _context.PersonCourses
            .FirstOrDefaultAsync(pc => pc.PersonId == personId && pc.CourseId == courseId);
    }

    public async Task<List<Course>> GetCoursesForPersonAsync(int personId)
    {
        return await _context.PersonCourses
            .Where(pc => pc.PersonId == personId)
            .Include(pc => pc.Course)       
            .Select(pc => pc.Course)   
            .ToListAsync();
    }
}