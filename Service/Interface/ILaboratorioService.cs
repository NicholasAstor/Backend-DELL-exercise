using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface ILaboratorioService
{
    public Task<List<Laboratorio>> GetAllAsync();
    public Task<Laboratorio?> GetByIdAsync(long id);
    public Task<Laboratorio> UpdateAsync(long id, LaboratorioDto dto);
}