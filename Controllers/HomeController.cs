using backend.Models;
using backend.Models.Dto;
using backend.Models.Enums;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly INotebookService _serviceNotebook;
        private readonly ILaboratorioService _serviceLaboratorio;
        private readonly IAlocacaoService _serviceAlocacao;
        private readonly IFuncionarioService _serviceFuncionario;
        private readonly ISalaService _serviceSala;

        public HomeController(INotebookService service, ILaboratorioService service2, IAlocacaoService service3, IFuncionarioService service4, ISalaService service5)
        {
            _serviceNotebook = service;
            _serviceLaboratorio = service2;
            _serviceAlocacao = service3;
            _serviceFuncionario = service4;
            _serviceSala = service5;
        }

        public async Task<ActionResult> Index()
        {
            var notebooks = await _serviceNotebook.GetAllAsync();
            var laboratorios = await _serviceLaboratorio.GetAllAsync();
            var salas = await _serviceSala.GetAllAsync();
            var alocacoes = await _serviceAlocacao.GetAllAsync();

            var viewModel = new HomeViewDto
            {
                Notebooks = notebooks,
                Laboratorios = laboratorios,
                Alocacoes = alocacoes,
                Salas = salas
            };

            return Ok(viewModel);
        }
        
        
        [HttpGet("recursos")]
        public async Task<ActionResult<DashboardDto>> GetNumeroRecursos([FromQuery] DateTime data)
        {
            var dataAlvo = data.Date;

            var notesTotais = await _serviceNotebook.GetAllAsync();
            var notesLivres = await _serviceNotebook.CountAvailableAsync(dataAlvo);
        
            var salasTotais = await _serviceSala.GetAllAsync();
            var salasLivres = await _serviceSala.CountAvailableAsync(dataAlvo);
        
            var labsTotais = await _serviceLaboratorio.GetAllAsync();
            var labsLivres = await _serviceLaboratorio.CountAvailableAsync(dataAlvo);

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
        
            var notebooks = await _serviceNotebook.GetAllAsync();
            var salas =  await _serviceSala.GetAllAsync();
            var labs = await _serviceLaboratorio.GetAllAsync();

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
}