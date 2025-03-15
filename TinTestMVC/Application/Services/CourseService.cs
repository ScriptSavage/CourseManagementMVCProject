using Application.DTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CourseService : ICourseService
{
    private readonly ICoursesRepository _repository;
    private readonly IMapper _mapper;

    public CourseService(ICoursesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CourseDetailsDto>> GetCoursesDetails()
    {
        var data = await _repository.GetCoursesDetails();

        var result = _mapper.Map<List<CourseDetailsDto>>(data);
        return result;
    }

    public async Task<CourseDetailsDto> GetCourseDetails(int Id)
    {
        var data = await _repository.GetCourseDetails(Id);

        var result = _mapper.Map<CourseDetailsDto>(data);
        return result;
    }

    public async Task<int> AddNewCourse(NewCourseDTO dto)
    {
        var newCourse = new Course()
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            MaxNumberOfStudents = dto.MaxNumberOfStudents,
            
            TutorId = dto.TutorId
        };
        
        var data = await _repository.AddNewCourse(newCourse);
        return data;
    }

    public async Task<int> UpdateCourseAsync(int courseId, EditCourseDTO dto)
    {
        var course = await _repository.GetCourseDetails(courseId);
        if (course == null)
        {
           
            return 0;
        }
        
        course.Description = dto.Description;
        course.Price = dto.Price;
        course.StartDate = dto.StartDate;
        course.EndDate = dto.EndDate;

        var result = await _repository.UpdateCourse(course);
        return result;
    }

    public async Task<int> DeleteCourseByID(int id)
    {
        var course = await _repository.GetCourseDetails(id);
        if (course == null)
        {
            return 0;
        }
        var result = await _repository.DeleteCourse(course);
        return result; 
    }

    public async Task<int> GetCurrentNumberOfStudentsAsync(int courseId)
    {
        return await _repository.GetCurrentNumberOfStudents(courseId);
    }

    public async Task<PagedResult<CourseDetailsDto>> GetCoursesPaged(int pageNumber, int pageSize)
    {
        var (items, totalCount) = await _repository.GetCoursesPaged(pageNumber, pageSize);

        var mapped = _mapper.Map<List<CourseDetailsDto>>(items);

        var result = new PagedResult<CourseDetailsDto>
        {
            Items = mapped,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        return result;
    }
}