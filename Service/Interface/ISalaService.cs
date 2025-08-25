using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ISalaService
{
    public Task<List<Sala>> GetAllAsync();
    public Task<Sala?> GetByIdAsync(long id);
    public Task<Sala> UpdateAsync(long id, SalaDto dto);
}