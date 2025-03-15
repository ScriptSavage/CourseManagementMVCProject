using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<Course, CourseDetailsDto>()
            .ForMember(dest => dest.Tutor, 
                opt => opt.MapFrom(src => src.Tutor))
            .ForMember(dest => dest.Persons,
                opt => opt.MapFrom(
                    src => src.PersonCourses.Select(pc => pc.Person).ToList()
                ));

        CreateMap<Tutor, TutorDto>();

        CreateMap<Person, PersonDto>();
    }
}