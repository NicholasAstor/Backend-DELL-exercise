using backend.Models;
using backend.Models.Dto;
using backend.Repository;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class SalaService : ISalaService
{
    private readonly ISalaRepository _repository;

    public SalaService(ISalaRepository repo)
    {
        _repository = repo;
    }
    public async Task<IEnumerable<SalaDto>> GetAllAsync()
    {
        var salas = await _repository.GetAllAsync();

        var result = salas.Select(s => new SalaDto(s.Numero, s.QtdLugares, s.TemProjetor)).ToList();

        return result;
    }
    public async Task<SalaDto?> GetByIdAsync(long id)
    {
        var sala = await _repository.GetByIdAsync(id);

        var result = new SalaDto(sala.Numero, sala.QtdLugares, sala.TemProjetor);

        return result;
    }

    public async Task<Sala> UpdateAsync(long id, SalaDto dto) => await _repository.UpdateAsync(id, dto.Numero, dto.QtdLugares, dto.TemProjetor);
}