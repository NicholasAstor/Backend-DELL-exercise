using backend.Data;
using backend.Models;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class NotebookRepository : INotebookRepository
{
    private readonly BackendDbContext _context;

    public NotebookRepository(BackendDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notebook>> GetAllAsync() => await _context.Notebooks
        .OrderBy(n => n.IdNotebook)
        .ToListAsync();

    public async Task<Notebook?> GetByIdAsync(long id) => await _context.Notebooks
        .FirstOrDefaultAsync(n => n.IdNotebook == id);

    public async Task<Notebook> AddAsync(Notebook notebook)
    {
        if (notebook == null)
        {
            throw new Exception("Erro ao criar notebook");
        }

        await _context.Notebooks.AddAsync(notebook);
        await _context.SaveChangesAsync();
        return notebook;
    }

    public async Task<Notebook> UpdateAsync(long id, int numeroPatrimonio, DateOnly dataAquisicao, string descricao)
    {
        var note = await _context.Notebooks.FirstOrDefaultAsync(n => n.IdNotebook == id);

        if (note == null)
        {
            throw new Exception($"Notebook com ID {id} não foi encontrado");
        }
        
        note.NumeroPatrimonio = numeroPatrimonio;
        note.DataAquisicao = dataAquisicao;
        note.Descricao =  descricao;
        
        await _context.SaveChangesAsync();
        return note;
        
    }


    public async Task DeleteAsync(long id)
    {
        var note = _context.Notebooks.FirstOrDefault(n => n.IdNotebook == id);

        if (note == null)
        {
            throw new Exception($"Notebook com ID {id} não foi encontrado");
        }

        _context.Notebooks.Remove(note);
        await _context.SaveChangesAsync();
    }
}