using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<Person, PersonDTO>()
            .ForMember(e => e.FirstName, e => e.MapFrom(e => e.FirstName))
            .ForMember(e => e.LastName, e => e.MapFrom(e => e.LastName));
    }
}