using backend.Models;
using backend.Models.Dto;
using backend.Models.Enums;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
public class HomeController : Controller
{
    public readonly INotebookService _notebookService;
    public readonly ISalaService _salaService;
    public readonly ILaboratorioService _laboratorioService;


    public HomeController(INotebookService notebookService, ISalaService salaService, ILaboratorioService laboratorioService)
    {
        _notebookService = notebookService;
        _salaService = salaService;
        _laboratorioService = laboratorioService;
    }

    [HttpGet("recursos")]
    public async Task<ActionResult<DashboardDto>> GetNumeroRecursos([FromQuery] DateTime data)
    {
        var dataAlvo = data.Date;

        var notesTotais = await _notebookService.GetAllAsync();
        var notesLivres = await _notebookService.CountAvailableAsync(dataAlvo);
        
        var salasTotais = await _salaService.GetAllAsync();
        var salasLivres = await _salaService.CountAvailableAsync(dataAlvo);
        
        var labsTotais = await _laboratorioService.GetAllAsync();
        var labsLivres = await _laboratorioService.CountAvailableAsync(dataAlvo);

        var dto = new DashboardDto(
            data,
            notesTotais.Count(),
            notesLivres,
            salasTotais.Count(),
            salasLivres,
            labsTotais.Count(),
            labsLivres);
        
        return Ok(dto);
    }

    [HttpGet("tabela")]
    public async Task<ActionResult<PagedModel<DashboardDto>>> GetInfo([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
    {
        if (pagina < 1)
        {
            return BadRequest("Página inválida");
        }
        
        var notebooks = await _notebookService.GetAllAsync();
        var salas =  await _salaService.GetAllAsync();
        var labs = await _laboratorioService.GetAllAsync();

        var info = new List<DashboardItemDto>(notebooks.Count() + salas.Count() + labs.Count());
        info.AddRange(notebooks.Select(n => new DashboardItemDto(TipoRecurso.Notebook, pagina, info)));
        info.AddRange(salas.Select(s => new DashboardItemDto(TipoRecurso.Sala, pagina, info)));
        info.AddRange(labs.Select(l => new DashboardItemDto(TipoRecurso.Laboratorio, pagina, info)));
        
        var numItems = info.Count();
        var numPaginas = (int)Math.Ceiling(numItems / (double)tamanho);
        var skip = (pagina - 1) * tamanho;
        
        var items = skip >= numItems ? new List<DashboardItemDto>() : info.Skip(skip).Take(tamanho).ToList();

        var result = new PagedModel<DashboardItemDto>(
            pagina,
            tamanho,
            numItems,
            numPaginas,
            items
        );
        
        return Ok(result);

    }
}
