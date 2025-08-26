using backend.Models.Enums;

namespace backend.Repository.Interface
{
    public interface IAlocacaoRepository
    {
        Task createAlocacao(long idRecurso, long idFuncionario, TipoRecurso tipoRecurso, DateTime reserva);
    }
}