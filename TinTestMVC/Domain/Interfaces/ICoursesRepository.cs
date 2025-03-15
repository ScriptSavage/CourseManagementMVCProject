using Domain.Entities;

namespace Domain.Interfaces;

public interface ICoursesRepository
{
    Task<List<Course>> GetCoursesDetails();
    Task<Course?> GetCourseDetails(int id);
    Task<int> AddNewCourse(Course course);
    Task<int> UpdateCourse(Course course);
   
    public Task<int> DeleteCourse(Course course);
    
    Task<int> GetCurrentNumberOfStudents(int courseId);
    
    Task<(List<Course> Items, int TotalCount)> GetCoursesPaged(int pageNumber, int pageSize);


}