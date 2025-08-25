using backend.Dto.Sala;
using backend.Models;

namespace backend.Repository;

public interface ISalaRepository
{
    public Task<List<Sala>> GetAllAsync();
    public Task<Sala?> GetByIdAsync(long id);
    public Task<Sala> UpdateAsync(long id,SalaDto dto);
}