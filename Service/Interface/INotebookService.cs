using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface INotebookService
{
    Task<IEnumerable<NotebookDto>>  GetAllAsync();
    Task<NotebookDto?> GetByIdAsync(long id);
    Task AddAsync(CreateNotebookDto dto);
    Task UpdateAsync(long id,CreateNotebookDto dto);
    Task DeleteAsync(long id);
}