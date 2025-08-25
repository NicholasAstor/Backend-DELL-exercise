using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface INotebookService
{
    public Task<IEnumerable<NotebookDto>>  GetAllAsync();
    public Task<NotebookDto?> GetByIdAsync(long id);
    public Task<NotebookDto> AddAsync(NotebookDto dto);
    public Task<Notebook> UpdateAsync(long id,Notebook dto);
    public Task DeleteAsync(long id);
}