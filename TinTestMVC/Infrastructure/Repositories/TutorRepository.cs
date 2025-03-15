using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly ProjectContext _context;

    public TutorRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<List<Tutor>> GetTutors()
    {
        var data = await _context.Tutors.ToListAsync();
        return data;
    }

    public async Task<int> AddNewTutor(Tutor tutor)
    {
        var data = await _context.Tutors.AddAsync(tutor);
        var result = await _context.SaveChangesAsync();
        return result;
    }
}