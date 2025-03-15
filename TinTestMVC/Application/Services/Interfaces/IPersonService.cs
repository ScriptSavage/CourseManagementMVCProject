using Application.DTO;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IPersonService
{
    Task<Person> GetByEmailAsync(string? userEmail);
    Task<List<PersonDTO>> GetPersons();
    
    Task AddNewPersonAsync(Person person);

}