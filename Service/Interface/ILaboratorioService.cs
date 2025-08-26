using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ILaboratorioService
{
    Task<IEnumerable<LaboratorioDto>> GetAllAsync();
    Task<LaboratorioDto?> GetByIdAsync(long id);
    Task<LaboratorioDto> UpdateAsync(long id, LaboratorioDto dto);
    
    Task<int> CountAvailableAsync(DateTime data);
}