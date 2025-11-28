using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS.Auth;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("register/passenger")]
    public async Task<IActionResult> RegisterPassenger([FromBody] RegisterPassengerDto dto)
    {
        try
        {
            var result = await _authService.RegisterPassengerAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("register/driver")]
    public async Task<IActionResult> RegisterDriver([FromBody] RegisterDriverDto dto)
    {
        try
        {
            var result = await _authService.RegisterDriverAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}