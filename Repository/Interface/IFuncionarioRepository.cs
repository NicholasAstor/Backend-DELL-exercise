using backend.Models;

namespace backend.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync();
    }
}