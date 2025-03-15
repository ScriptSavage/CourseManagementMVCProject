using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PersonCourseService : IPersonCourseService
{
    private readonly IPersonCoursesRepository _repository;

    public PersonCourseService(IPersonCoursesRepository repository)
    {
        _repository = repository;
    }


    public async Task<bool> EnrollPersonInCourse(int personId, int courseId)
    {
        var existing = await _repository.GetPersonCourse(personId, courseId);
        if (existing != null)
        {
            return false;
        }

        var newEnrollment = new PersonCourses
        {
            PersonId = personId,
            CourseId = courseId,
            RegistrationDate = DateTime.Now
        };

        await _repository.AddPersonCourse(newEnrollment);
        return true;
    }

    public async Task<List<CourseDetailsDto>> GetUserCoursesAsync(int personId)
    {
        var courses = await _repository.GetCoursesForPersonAsync(personId);
       
        var result = courses.Select(c => new CourseDetailsDto
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Price = c.Price,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
        }).ToList();

        return result;
    }
}