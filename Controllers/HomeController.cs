using backend.Models.Dto;
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
}