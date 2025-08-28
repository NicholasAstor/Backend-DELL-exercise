using System.Runtime.InteropServices;
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

        public async Task<IEnumerable<RecursoDto>> GetAllAsync(DateTime? data = null)
        {
            data ??= DateTime.Today.ToUniversalTime();

            var recursos = new List<RecursoDto>();

            recursos.AddRange(await _context.Notebooks
            .Select(n => new RecursoDto
            {
                Id = n.IdNotebook,
                Tipo = "Notebook",
                NomeOuDescricao = n.Descricao,
                Disponivel = !_context.Alocacoes.Any(a => a.IdRecurso == n.IdNotebook && a.TipoRecurso == TipoRecurso.Notebook && a.DataReserva.Date == data.Value.Date),
                DataReserva = _context.Alocacoes
                .Where(a => a.IdRecurso == n.IdNotebook
                    && a.TipoRecurso == TipoRecurso.Notebook
                    && a.DataReserva.Date == data.Value.Date)
                    .Select(a => (DateTime?)a.DataReserva)
                    .FirstOrDefault().ToDateOnly()
            }).ToListAsync());

            recursos.AddRange(await _context.Salas
            .Select(s => new RecursoDto
            {
                Id = s.IdSala,
                Tipo = "Sala",
                NomeOuDescricao = $"Sala {s.Numero} ({s.QtdLugares} lugares)",
                Disponivel = !_context.Alocacoes.Any(a => a.IdRecurso == s.IdSala && a.TipoRecurso == TipoRecurso.Sala && a.DataReserva.Date == data.Value.Date),
                DataReserva = _context.Alocacoes.Where(a => a.IdRecurso == s.IdSala && a.TipoRecurso == TipoRecurso.Sala && a.DataReserva.Date == data.Value.Date).Select(a => (DateTime?)a.DataReserva).FirstOrDefault().ToDateOnly()
            }).ToListAsync());

            recursos.AddRange(await _context.Laboratorios
            .Select(l => new RecursoDto
            {
                Id = l.IdLaboratorio,
                Tipo = "Laboratório",
                NomeOuDescricao = l.Nome,
                Disponivel = !_context.Alocacoes.Any(a => a.IdRecurso == l.IdLaboratorio && a.TipoRecurso == TipoRecurso.Laboratorio && a.DataReserva.Date == data.Value.Date),
                DataReserva = _context.Alocacoes.Where(a => a.IdRecurso == l.IdLaboratorio && a.TipoRecurso == TipoRecurso.Laboratorio && a.DataReserva.Date == data.Value.Date).Select(a => (DateTime?)a.DataReserva).FirstOrDefault().ToDateOnly()
            }).ToListAsync());

            return recursos;
        }

        public async Task<string> FilterAlocacoesByDiasDaSemanaMaisOcupados()
        {
            var alocacoes = await _context.Alocacoes
            .GroupBy(a => a.DataReserva.DayOfWeek)
            .Select(g => new { DiaDaSemana = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .ToListAsync();

            var diasMaisOcupados = alocacoes.Take(5).Select(a => a.DiaDaSemana.ToString()).ToList();

            return diasMaisOcupados.FirstOrDefault();
        }
    }
}