using backend.Models;

namespace backend.Repository.Interface;

public interface ISalaRepository
{
    Task<IEnumerable<Sala>> GetAllAsync();
    Task<Sala?> GetByIdAsync(long id);
    Task<Sala> UpdateAsync(long id, int numero, int qtdLugares, bool temProjetor);
}