using backend.Data;
using backend.Dto.Laboratorio;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository.Impl;

public class LaboratorioRepository(BackendDbContext context) : ILaboratorioRepository
{
    public async Task<List<Laboratorio>> GetAllAsync()
    {
        return await context.Laboratorios.AsNoTracking()
            .OrderBy(n => n.IdLaboratorio)
            .ToListAsync();
    }

    public async Task<Laboratorio?> GetByIdAsync(long id)
    {
        return await context.Laboratorios.AsNoTracking()
            .FirstOrDefaultAsync(s => s.IdLaboratorio == id);
    }

    public async Task<Laboratorio> UpdateAsync(long id, LaboratorioDto dto)
    {
        var lab = await context.Laboratorios.FirstOrDefaultAsync(l => l.IdLaboratorio == id);
        if (lab == null)
            throw new ArgumentNullException($"Laboratorio com ID {id} não foi encontrado");
        
        lab.Nome = dto.Nome;
        lab.QtdComputadores = dto.QtdComputadores;
        lab.Descricao = dto.Descricao;

        await context.SaveChangesAsync();
        return lab;
    }

}