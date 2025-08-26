using backend.Models;
using backend.Models.Dto;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlocacaoController : Controller
    {
        private readonly IAlocacaoService _service;

        public AlocacaoController(IAlocacaoService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAlocacaoDto alocacao)
        {
            await _service.createAlocacao(alocacao);
            return Created();
        }
    }
}