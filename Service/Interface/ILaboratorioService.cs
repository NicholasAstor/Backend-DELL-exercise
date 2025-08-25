using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ILaboratorioService
{
    public Task<IEnumerable<LaboratorioDto>> GetAllAsync();
    public Task<LaboratorioDto?> GetByIdAsync(long id);
    public Task<LaboratorioDto> UpdateAsync(long id, LaboratorioDto dto);
}