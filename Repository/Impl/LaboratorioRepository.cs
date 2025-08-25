using backend.Data;
using backend.Models;
using backend.Repository.Interface;
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

    public async Task<Laboratorio> UpdateAsync(long id, string nome, int qtdComputadores, string descricao)
    {
        var lab = await context.Laboratorios.FirstOrDefaultAsync(l => l.IdLaboratorio == id);
        if (lab == null)
            throw new ArgumentNullException($"Laboratorio com ID {id} não foi encontrado");
        
        lab.Nome = nome;
        lab.Descricao = descricao;
        lab.QtdComputadores = qtdComputadores;
        
        await context.SaveChangesAsync();
        return lab;
    }

}