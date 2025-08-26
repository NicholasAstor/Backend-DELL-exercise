using backend.Models.Dto;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service
{
    public class AlocacaoService : IAlocacaoService
    {
        private readonly IAlocacaoRepository _repository;

        public AlocacaoService(IAlocacaoRepository repo) => _repository = repo;

        public async Task CreateAlocacao(CreateAlocacaoDto alocacaoDto) => await _repository.createAlocacao(alocacaoDto.IdRecurso, alocacaoDto.IdFuncionario, alocacaoDto.TipoRecurso, alocacaoDto.DataReserva);
    }
}