using backend.Models;

namespace backend.Repository.Interface;

public interface ISalaRepository
{
    public Task<IEnumerable<Sala>> GetAllAsync();
    public Task<Sala?> GetByIdAsync(long id);
    public Task<Sala> UpdateAsync(long id, int numero, int qtdLugares, bool temProjetor);
}