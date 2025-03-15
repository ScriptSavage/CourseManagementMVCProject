using Domain.Entities;

namespace Domain.Interfaces;

public interface ITutorRepository
{
    Task<List<Tutor>> GetTutors();
    Task<int> AddNewTutor(Tutor tutor);
}