using backend.Models;

namespace backend.Repository.Interface;

public interface ILaboratorioRepository
{
    public Task<IEnumerable<Laboratorio>> GetAllAsync();
    public Task<Laboratorio?> GetByIdAsync(long id);
    public Task<Laboratorio> UpdateAsync(long id, string nome, int qtdComputadores, string descricao);
}