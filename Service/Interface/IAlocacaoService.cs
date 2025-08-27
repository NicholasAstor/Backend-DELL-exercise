using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface
{
    public interface IAlocacaoService
    {
        Task createAlocacao(CreateAlocacaoDto alocacaoDto);
        Task<IEnumerable<Alocacao>> GetAllAsync();
    }
}