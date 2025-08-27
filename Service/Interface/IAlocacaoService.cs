using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface
{
    public interface IAlocacaoService
    {
        Task createAlocacao(CreateAlocacaoDto alocacaoDto);
        Task<string> FilterAlocacoesByDiasMaisOcupados();
        Task<IEnumerable<RecursoDto>> GetAllAsync(DateTime? data = null);
    }
}