using backend.Data;
using backend.Models;
using backend.Models.Enums;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class AlocacaoRepository : IAlocacaoRepository
    {
        private readonly BackendDbContext _context;

        public AlocacaoRepository(BackendDbContext context)
        {
            _context = context;
        }

        public async Task createAlocacao(long idRecurso, long idFuncionario, TipoRecurso tipoRecurso, DateTime reserva)
        {
            if (idRecurso == 0 || idFuncionario == 0)
            {
                throw new Exception("Erro ao criar alocação");
            }
         
            var dataReserva = reserva.ToUniversalTime();
            var dataCriacao = DateTime.Now.ToUniversalTime();
            var alocacaoNova = new Alocacao
            {
                FuncionarioId = idFuncionario,
                IdRecurso = idRecurso,
                TipoRecurso = tipoRecurso,
                DataReserva = dataReserva,
                DataCriacao = dataCriacao
            };

            var alocacoes = await _context.Alocacoes
            .Where(a => a.DataReserva.Day == dataReserva.Day && a.TipoRecurso == tipoRecurso && a.IdRecurso == idRecurso)
            .ToListAsync();

            if (alocacoes.Count != 0)
            {
                throw new Exception("Já existe uma reserva para esse dia");
            } 
            
            await _context.Alocacoes.AddAsync(alocacaoNova);
            await _context.SaveChangesAsync();
        }
    }
}