using backend.Data;
using backend.Dto.Sala;
using backend.Models;
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

    public async Task<Sala> UpdateAsync(long id, SalaDto dto)
    {
        var sala = await context.Salas.FirstOrDefaultAsync(s => s.IdSala == id);
        if (sala == null)
            throw new ArgumentNullException($"Sala com ID {id} não foi encontrada");
        
        sala.Numero = dto.Numero;
        sala.QtdLugares = dto.QtdLugares;
        sala.TemProjetor = dto.TemProjetor;
        
        await context.SaveChangesAsync();

        return sala;
    }
}