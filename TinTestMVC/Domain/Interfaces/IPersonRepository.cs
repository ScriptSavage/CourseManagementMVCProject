using Domain.Entities;

namespace Domain.Interfaces;

public interface IPersonRepository
{
    
    Task<Person?> GetByEmailAsync(string? userEmail);
    Task<List<Person>> GetPersons();
    Task AddNewPersonAsync(Person person);
}