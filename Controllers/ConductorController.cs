using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/conductor")]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorService _service;
        private readonly IViajeService _viajes;
        public ConductorController(IConductorService service, IViajeService viajes)
        {
            _service = service;
            _viajes = viajes;
        }

        // GET: api/conductor
        [HttpGet]
        public async Task<IActionResult> GetAllConductores()
        {
            IEnumerable<Conductor> items = await _service.GetAll();
            return Ok(items);
        }

        // GET: api/conductor/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var conductor = await _service.GetOne(id);
            return Ok(conductor);
        }

        // POST: api/conductor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConductorDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Created($"api/conductor/{id}", new { id });
        }

        // PUT: api/conductor/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateConductor([FromBody] UpdateConductorDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var conductor = await _service.UpdateConductor(dto, id);
            return CreatedAtAction(nameof(GetOne), new { id = conductor.Id }, conductor);
        }

        // DELETE: api/conductor/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteConductor(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.DeleteConductor(id);
            return NoContent();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterConductorDto dto)
        {
            var id = await _service.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id }, null);
        }

        
    }
}
