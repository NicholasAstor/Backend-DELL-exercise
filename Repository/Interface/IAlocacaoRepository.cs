using backend.Models;
using backend.Models.Dto;
using backend.Models.Enums;

namespace backend.Repository.Interface
{
    public interface IAlocacaoRepository
    {
        Task createAlocacao(long idRecurso, long idFuncionario, TipoRecurso tipoRecurso, DateTime reserva);
        Task<IEnumerable<RecursoDto>> GetAllAsync(DateTime? data = null);
        Task<string> FilterAlocacoesByDiasDaSemanaMaisOcupados();
    }
}