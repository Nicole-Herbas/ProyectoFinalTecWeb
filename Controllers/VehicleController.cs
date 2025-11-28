using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS.Vehicle;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers;

[ApiController]
[Route("api/vehicles")]
[Authorize]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _service;

    public VehicleController(IVehicleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vehicle = await _service.GetByIdAsync(id);
        if (vehicle == null) return NotFound();
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}