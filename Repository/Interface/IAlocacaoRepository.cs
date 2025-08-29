using backend.Models;
using backend.Models.Enums;

namespace backend.Repository.Interface
{
    public interface IAlocacaoRepository
    {
        Task createAlocacao(long idRecurso, long idFuncionario, TipoRecurso tipoRecurso, DateTime reserva);
        Task<IEnumerable<RecursoDto>> GetAllAsync(DateTime? dataInicio = null, DateTime? dataFim = null);
        Task<string> FilterAlocacoesByDiasDaSemanaMaisOcupados();
    }
}