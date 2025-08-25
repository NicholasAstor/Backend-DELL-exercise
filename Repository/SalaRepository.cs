using backend.Data;
using backend.Models;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class SalaRepository(BackendDbContext _context) : ISalaRepository
{
    public async Task<IEnumerable<Sala>> GetAllAsync() => await _context.Salas
    .OrderBy(n => n.IdSala)
    .ToListAsync();

    public async Task<Sala?> GetByIdAsync(long id) => await _context.Salas
    .FirstOrDefaultAsync(s => s.IdSala == id);

    public async Task<Sala> UpdateAsync(long id, int numero, int qtdLugares, bool temProjetor)
    {
        var sala = await _context.Salas.FirstOrDefaultAsync(s => s.IdSala == id);

        if (sala == null)
            throw new Exception($"Sala com ID {id} não foi encontrada");

        sala.Numero = numero;
        sala.QtdLugares = qtdLugares;
        sala.TemProjetor = temProjetor;
        
        await _context.SaveChangesAsync();
        
        return sala;
    }
    
}