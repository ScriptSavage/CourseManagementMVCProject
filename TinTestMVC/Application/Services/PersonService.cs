using Application.DTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Person> GetByEmailAsync(string? userEmail)
    {
        var result = _repository.GetByEmailAsync(userEmail);
        return result;
    }

    public async Task<List<PersonDTO>> GetPersons()
    {
        var data = await _repository.GetPersons();
        var result = _mapper.Map<List<PersonDTO>>(data);
        return result;
    }

    public async Task AddNewPersonAsync(Person person)
    {
        await _repository.AddNewPersonAsync(person);
    }
}