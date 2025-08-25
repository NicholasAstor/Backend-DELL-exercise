using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ISalaService
{
    public Task<IEnumerable<SalaDto>> GetAllAsync();
    public Task<SalaDto?> GetByIdAsync(long id);
    public Task<Sala> UpdateAsync(long id, SalaDto dto);
}