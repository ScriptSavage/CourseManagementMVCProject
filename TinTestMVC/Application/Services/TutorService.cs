using Application.DTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class TutorService : ITutorService
{
    private readonly ITutorRepository _repository;
    private readonly IMapper _mapper;

    public TutorService(ITutorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TutorDTO>> GetTutors()
    {
        var data = await _repository.GetTutors();
        var result =  _mapper.Map<List<TutorDTO>>(data);
        return result;
    }

    public async Task<int> AddNewTutorAsync(TutorDTO dto)
    {
        var newTutor = new Tutor()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            AboutMe = dto.AboutMe,
            Specialisation = dto.Specialisation
        };
        var data = await _repository.AddNewTutor(newTutor);
        return data;
    }
}