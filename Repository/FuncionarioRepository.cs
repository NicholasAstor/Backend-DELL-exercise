using backend.Data;
using backend.Models;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly BackendDbContext _context;

        public FuncionarioRepository(BackendDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync() => await _context.Funcionarios
        .OrderBy(f => f.IdFuncionario)
        .ToListAsync();
    }
}