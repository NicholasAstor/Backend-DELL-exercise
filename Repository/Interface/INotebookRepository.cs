using backend.Models;

namespace backend.Repository.Interface;

public interface INotebookRepository
{
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task<Notebook?> GetByIdAsync(long id);
    Task<Notebook> AddAsync(Notebook notebook);
    Task<Notebook> UpdateAsync(long id, int numeroPatrimonio, DateOnly dataAquisicao, string descricao);
    Task DeleteAsync(long id);
    
    Task<int> CountAvailableAsync(int total, DateTime data);
}