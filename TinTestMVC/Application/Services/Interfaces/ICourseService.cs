using Application.DTO;

namespace Application.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseDetailsDto>> GetCoursesDetails();

    Task<CourseDetailsDto> GetCourseDetails(int id);

    Task<int> AddNewCourse(NewCourseDTO dto);

    Task<int> UpdateCourseAsync(int courseId, EditCourseDTO dto);
    
    Task<int> DeleteCourseByID(int id);
    
    Task<int> GetCurrentNumberOfStudentsAsync(int courseId);
    
    Task<PagedResult<CourseDetailsDto>> GetCoursesPaged(int pageNumber, int pageSize);


}