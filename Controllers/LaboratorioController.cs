using backend.Models;
using backend.Models.Dto;
using backend.Service.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaboratorioController : Controller
    {
        private readonly ILaboratorioService _service;

        public LaboratorioController(ILaboratorioService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<ActionResult<LaboratorioDto>> GetById(long id)
        {
            var laboratorio = await _service.GetByIdAsync(id);

            if (laboratorio == null)
            {
                return NotFound("Não existe laboratorio com esse id");
            }

            return Ok(laboratorio);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaboratorioDto>>> GetAll()
        {
            var laboratorios = await _service.GetAllAsync();

            if (laboratorios == null)
            {
                return NotFound("Não existem laboratórios cadastrados");
            }

            return Ok(laboratorios);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LaboratorioDto>> Update(long id, [FromBody] LaboratorioDto laboratorio)
        {
            var lab = await _service.UpdateAsync(id, laboratorio);

            if (lab == null)
            {
                return NotFound("Não foi possível atualizar");
            }

            return Ok(lab);
        }
    }
}