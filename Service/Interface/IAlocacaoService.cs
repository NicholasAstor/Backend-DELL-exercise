using backend.Models.Dto;

namespace backend.Service.Interface
{
    public interface IAlocacaoService
    {
        Task CreateAlocacao(CreateAlocacaoDto alocacaoDto);
    }
}