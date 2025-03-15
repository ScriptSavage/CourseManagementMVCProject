using Application.DTO;

namespace Application.Services.Interfaces;

public interface ITutorService
{
    Task<List<TutorDTO>> GetTutors();
    Task<int> AddNewTutorAsync(TutorDTO dto);
}