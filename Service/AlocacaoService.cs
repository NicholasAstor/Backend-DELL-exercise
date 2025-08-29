using backend.Models;
using backend.Models.Dto;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service
{
    public class AlocacaoService : IAlocacaoService
    {
        private readonly IAlocacaoRepository _repository;

        public AlocacaoService(IAlocacaoRepository repo) => _repository = repo;

        public async Task createAlocacao(CreateAlocacaoDto alocacaoDto) => await _repository.createAlocacao(alocacaoDto.IdRecurso, alocacaoDto.IdFuncionario, alocacaoDto.TipoRecurso, alocacaoDto.DataReserva);
        public async Task<string> FilterAlocacoesByDiasMaisOcupados() => await _repository.FilterAlocacoesByDiasDaSemanaMaisOcupados();
        public async Task<IEnumerable<RecursoDto>> GetAllAsync(DateTime? dataInicio = null, DateTime? dataFim = null) => await _repository.GetAllAsync(dataInicio, dataFim);
    }
}