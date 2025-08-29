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

        [HttpGet("dias-mais-ocupados")]
        public async Task<ActionResult> DiasMaisOcupados()
        {
            var alocacoes = await _serviceAlocacao.FilterAlocacoesByDiasMaisOcupados();

            return Ok(alocacoes);
        }
        
        [HttpGet("recursos")]
        public async Task<ActionResult> Recursos([FromQuery] DateTime? dataInicio, [FromQuery] DateTime? dataFim)
        {
            var recursos = await _serviceAlocacao.GetAllAsync(dataInicio, dataFim);
            return Ok(recursos);
        }
    }
}