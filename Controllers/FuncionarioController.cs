using backend.Models.Dto;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _service;

        public FuncionarioController(IFuncionarioService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDto>>> GetAll()
        {
            var funcionarios = await _service.GetAllFuncionariosAsync();

            if (funcionarios == null)
            {
                return NotFound("Não temos usuários cadastrados");
            }

            return Ok(funcionarios);
        }
    }
}