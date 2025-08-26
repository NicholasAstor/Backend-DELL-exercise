using backend.Models;

namespace backend.Repository.Interface;

public interface ILaboratorioRepository
{
    Task<IEnumerable<Laboratorio>> GetAllAsync();
    Task<Laboratorio?> GetByIdAsync(long id);
    Task<Laboratorio> UpdateAsync(long id, string nome, int qtdComputadores, string descricao);
    
    Task<int> CountAvailableAsync(DateTime data);
}