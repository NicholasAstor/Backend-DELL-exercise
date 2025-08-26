using backend.Models;
using backend.Models.Dto;

namespace backend.Service.Interface;

public interface INotebookService
{
    Task<IEnumerable<NotebookDto>>  GetAllAsync();
    Task<NotebookDto?> GetByIdAsync(long id);
    Task<NotebookDto> AddAsync(NotebookDto dto);
    Task<Notebook> UpdateAsync(long id,Notebook dto);
    Task DeleteAsync(long id);
}