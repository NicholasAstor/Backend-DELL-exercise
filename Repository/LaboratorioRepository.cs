using backend.Data;
using backend.Models;
using backend.Models.Enums;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class LaboratorioRepository : ILaboratorioRepository
{
    private readonly BackendDbContext _context;
    public LaboratorioRepository(BackendDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Laboratorio>> GetAllAsync() => await _context.Laboratorios
    .OrderBy(n => n.IdLaboratorio)
    .ToListAsync();

    public async Task<Laboratorio?> GetByIdAsync(long id) => await _context.Laboratorios
    .FirstOrDefaultAsync(s => s.IdLaboratorio == id);

    public async Task<Laboratorio> UpdateAsync(long id, string nome, int qtdComputadores, string descricao)
    {
        var lab = await _context.Laboratorios.FirstOrDefaultAsync(l => l.IdLaboratorio == id);

        if (lab == null)
        {
            throw new Exception($"Laboratorio com ID {id} não foi encontrado");
        }
        
        lab.Nome = nome;
        lab.Descricao = descricao;
        lab.QtdComputadores = qtdComputadores;
        
        await _context.SaveChangesAsync();
        return lab;
    }
    
    public async Task<int> CountAvailableAsync(DateTime data)
    {
        var dataAlvo = data.Date;
        
        var totalLabs = await _context.Laboratorios.CountAsync();
        
        var labsOcupados = await _context.Alocacoes
            .Where(a => a.TipoRecurso == TipoRecurso.Laboratorio && a.DataReserva.Date == dataAlvo)
            .Select(a => a.IdRecurso)
            .Distinct()
            .CountAsync();

        return totalLabs - labsOcupados;
    }
}