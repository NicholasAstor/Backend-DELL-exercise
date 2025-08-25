using backend.Data;
using backend.Models;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository.Impl;

public class SalaRepository(BackendDbContext context) : ISalaRepository
{
    public async Task<List<Sala>> GetAllAsync()
    {
        return await context.Salas.AsNoTracking()
            .OrderBy(n => n.IdSala)
            .ToListAsync();
    }

    public async Task<Sala?> GetByIdAsync(long id)
    {
        return await context.Salas.AsNoTracking()
            .FirstOrDefaultAsync(s => s.IdSala == id);
    }

    public async Task<Sala> UpdateAsync(long id, int numero, int qtdLugares, bool temProjetor)
    {
        var sala = await context.Salas.FirstOrDefaultAsync(s => s.IdSala == id);
        if (sala == null)
            throw new ArgumentNullException($"Sala com ID {id} não foi encontrada");
        sala.Numero = numero;
        sala.QtdLugares = qtdLugares;
        sala.TemProjetor = temProjetor;
        
        await context.SaveChangesAsync();
        
        return sala;
    }
    
}