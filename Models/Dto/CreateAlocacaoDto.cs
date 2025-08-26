using backend.Models.Enums;

namespace backend.Models.Dto
{
    public record CreateAlocacaoDto(long IdFuncionario, long IdRecurso, TipoRecurso TipoRecurso, DateTime DataReserva);
}