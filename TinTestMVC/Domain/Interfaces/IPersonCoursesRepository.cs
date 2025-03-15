using Domain.Entities;

namespace Domain.Interfaces;

public interface IPersonCoursesRepository
{
    Task AddPersonCourse(PersonCourses personCourse);
    Task<PersonCourses?> GetPersonCourse(int personId, int courseId);
    Task<List<Course>> GetCoursesForPersonAsync(int personId);

}