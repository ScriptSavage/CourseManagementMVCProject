using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class TutorMapper : Profile
{
    public TutorMapper()
    {
        CreateMap<Tutor, TutorDTO>()
            .ForMember(e => e.LastName, e => e.MapFrom(e => e.LastName))
            .ForMember(e => e.FirstName, e => e.MapFrom(e => e.FirstName))
            .ForMember(e => e.Specialisation, e => e.MapFrom(e => e.Specialisation))
            .ForMember(e => e.AboutMe, e => e.MapFrom(e => e.AboutMe));
    }
}