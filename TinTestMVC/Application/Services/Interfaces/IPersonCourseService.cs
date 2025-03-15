using Application.DTO;

namespace Application.Services.Interfaces;

public interface IPersonCourseService
{
    Task<bool> EnrollPersonInCourse(int personId, int courseId);
    Task<List<CourseDetailsDto>> GetUserCoursesAsync(int personId);
}