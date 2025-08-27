using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Dto;

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
    }
}