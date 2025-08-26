using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ISalaService
{
    Task<IEnumerable<SalaDto>> GetAllAsync();
    Task<SalaDto?> GetByIdAsync(long id);
    Task<Sala> UpdateAsync(long id, SalaDto dto);
    
    Task<int> CountAvailableAsync(DateTime data);
}