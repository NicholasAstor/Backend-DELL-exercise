using backend.Models.Dto;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repo)
        {
            _repository = repo;
        }

        public async Task<IEnumerable<FuncionarioDto>> GetAllFuncionariosAsync()
        {
            var funcionarios = await _repository.GetAllFuncionariosAsync();

            var result = funcionarios.Select(f => new FuncionarioDto(f.Nome, f.Cargo));

            return result;
        }
    }
}