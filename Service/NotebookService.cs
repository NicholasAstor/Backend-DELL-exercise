using backend.Models;
using backend.Models.Dto;
using backend.Repository;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class NotebookService : INotebookService
{

    private readonly INotebookRepository _repository;

    public NotebookService(INotebookRepository repo)
    {
        _repository = repo;
    }
    public async Task<IEnumerable<NotebookDto>> GetAllAsync()
    {
        var notebooks = await _repository.GetAllAsync();

        var result = notebooks
            .Select(n => new NotebookDto
                (n.NumeroPatrimonio, n.DataAquisicao, n.Descricao)).ToList();

        return result;
    }

    public async Task<NotebookDto?> GetByIdAsync(long id)
    {
        var n = await _repository.GetByIdAsync(id);

   
            var result = new NotebookDto
                (n.NumeroPatrimonio, n.DataAquisicao, n.Descricao);
            
        return result;
    }

    public async Task<NotebookDto> AddAsync(NotebookDto dto)
    {
        var entity = new Notebook
        {
            NumeroPatrimonio = dto.NumeroPatrimonio,
            DataAquisicao = dto.DataAquisicao,
            Descricao = dto.Descricao
        };

        var updated = await _repository.AddAsync(entity);

        return new NotebookDto(updated.NumeroPatrimonio, updated.DataAquisicao, updated.Descricao);
    }

    public async Task<Notebook> UpdateAsync(long id, Notebook dto) => await
        _repository.UpdateAsync(id, dto.NumeroPatrimonio, dto.DataAquisicao, dto.Descricao);
 

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }
}