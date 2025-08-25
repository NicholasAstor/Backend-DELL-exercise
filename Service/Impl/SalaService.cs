using backend.Models;
using backend.Models.Dto;
using backend.Repository.Impl;
using backend.Service.Interface;

namespace backend.Service.Impl;

public class SalaService (SalaRepository repository) : ISalaService
{
    public async Task<List<Sala>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Sala?> GetByIdAsync(long id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Sala> UpdateAsync(long id, SalaDto dto)
    {
        return await repository.UpdateAsync(id, dto.Numero, dto.QtdLugares, dto.TemProjetor);
    }
}