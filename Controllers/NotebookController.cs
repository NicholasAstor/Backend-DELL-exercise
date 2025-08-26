using backend.Models.Dto;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("[controller]")]
public class NotebookController : Controller
{
    private readonly INotebookService _service;

    public NotebookController(INotebookService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult> Create([FromBody]CreateNotebookDto dto)
    {
        await _service.AddAsync(dto);
        return Created();
    }
        
    
    [HttpGet("{id}")]
    public async Task<ActionResult<NotebookDto>> GetById(long id)
    {
        var notebook = await _service.GetByIdAsync(id);

        if (notebook == null)
        {
            return NotFound("Não existe notebook com esse id");
        }

        return Ok(notebook);
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotebookDto>>> GetAllAsync() 
    {
        var notebooks = await _service.GetAllAsync();

        if (notebooks == null)
        {
            return NotFound("Não existem notebooks cadastrados");
        }

        return Ok(notebooks);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(long id, [FromBody]CreateNotebookDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return Created();
    }
}