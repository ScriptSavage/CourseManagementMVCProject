using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ProjectContext _context;

    public PersonRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetByEmailAsync(string? userEmail)
    {

        var data = await _context.Persons.Where(e => e.Email == userEmail).FirstOrDefaultAsync();
        return data;
    }

    public async Task<List<Person>> GetPersons()
    {
        var data = await _context.Persons.ToListAsync();
        return data;
    }

    public async Task AddNewPersonAsync(Person person)
    {
        var data = await _context.Persons.AddAsync(person);
       await _context.SaveChangesAsync();
    }
}