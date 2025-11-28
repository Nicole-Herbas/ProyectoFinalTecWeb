using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
        [ApiController]
        [Route("api/pasajero")]
        public class PasajeroController : ControllerBase
        {
            private readonly IPasajeroService _service;
            private readonly IViajeService _viajes;
            public PasajeroController(IPasajeroService service, IViajeService viajes)
            {
                _service = service;
                _viajes = viajes;
            }

            // GET: api/pasajero
            [HttpGet]
            public async Task<IActionResult> GetAllPasajeros()
            {
                IEnumerable<Pasajero> items = await _service.GetAll();
                return Ok(items);
            }

            // GET: api/pasajero/{id}
            [HttpGet("{id:guid}")]
            public async Task<IActionResult> GetOne(Guid id)
            {
                var pasajero = await _service.GetOne(id);
                return Ok(pasajero);
            }

            // POST: api/pasajero
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreatePasajeroDto dto)
            {
                var id = await _service.CreateAsync(dto);
                return Created($"api/pasajero/{id}", new { id });
            }

            // PUT: api/pasajero/{id}
            [HttpPut("{id:guid}")]
            public async Task<IActionResult> UpdatePasajero([FromBody] UpdatePasajeroDto dto, Guid id)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);
                var pasajero = await _service.UpdatePasajero(dto, id);
                return CreatedAtAction(nameof(GetOne), new { id = pasajero.Id }, pasajero);
            }

            // DELETE: api/pasajero/{id}
            [HttpDelete("{id:guid}")]
            public async Task<IActionResult> DeletePasajero(Guid id)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);
                await _service.DeletePasajero(id);
                return NoContent();
            }



            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterPasajeroDto dto)
            {
                var id = await _service.RegisterAsync(dto);
                return CreatedAtAction(nameof(Register), new { id }, null);
            }


        }
    
}
