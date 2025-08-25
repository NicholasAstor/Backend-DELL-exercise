using backend.Models;

namespace backend.Repository.Interface;

public interface INotebookRepository
{
    public Task<IEnumerable<Notebook>> GetAllAsync();
    public Task<Notebook?> GetByIdAsync(long id);
    public Task<Notebook> AddAsync(Notebook notebook);
    public Task<Notebook> UpdateAsync(long id, int numeroPatrimonio, DateTime dataAquisicao, string descricao);
    public Task DeleteAsync(long id);
}