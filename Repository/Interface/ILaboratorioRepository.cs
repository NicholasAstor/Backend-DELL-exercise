using backend.Dto.Laboratorio;
using backend.Dto.Sala;
using backend.Models;

namespace backend.Repository;

public interface ILaboratorioRepository
{
    public Task<List<Laboratorio>> GetAllAsync();
    public Task<Laboratorio?> GetByIdAsync(long id);
    public Task<Laboratorio> UpdateAsync(long id, LaboratorioDto dto);
}