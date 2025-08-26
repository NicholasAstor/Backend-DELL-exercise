using backend.Models.Dto;

namespace backend.Service.Interface
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDto>> GetAllFuncionariosAsync();
    }
}