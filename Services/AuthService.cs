using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS.Auth;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services;

public class AuthService : IAuthService
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IPassengerRepository passengerRepository, IDriverRepository driverRepository, IConfiguration configuration)
    {
        _passengerRepository = passengerRepository;
        _driverRepository = driverRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var passenger = await _passengerRepository.GetByEmailAsync(dto.Email);
        if (passenger != null)
        {
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, passenger.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var token = GenerateToken(passenger.Id.ToString(), passenger.Email, "Passenger");
            return new LoginResponseDto
            {
                Id = passenger.Id,
                Email = passenger.Email,
                Role = "Passenger",
                Token = token
            };
        }

        var driver = await _driverRepository.GetByEmailAsync(dto.Email);
        if (driver != null)
        {
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, driver.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var token = GenerateToken(driver.Id.ToString(), driver.Email, "Driver");
            return new LoginResponseDto
            {
                Id = driver.Id,
                Email = driver.Email,
                Role = "Driver",
                Token = token
            };
        }

        throw new Exception("User not found");
    }

    public async Task<LoginResponseDto> RegisterPassengerAsync(RegisterPassengerDto dto)
    {
        var existing = await _passengerRepository.GetByEmailAsync(dto.Email);
        if (existing != null) throw new Exception("Email already in use");

        var passenger = new Passenger
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        await _passengerRepository.AddAsync(passenger);

        var token = GenerateToken(passenger.Id.ToString(), passenger.Email, "Passenger");
        return new LoginResponseDto
        {
            Id = passenger.Id,
            Email = passenger.Email,
            Role = "Passenger",
            Token = token
        };
    }

    public async Task<LoginResponseDto> RegisterDriverAsync(RegisterDriverDto dto)
    {
        var existing = await _driverRepository.GetByEmailAsync(dto.Email);
        if (existing != null) throw new Exception("Email already in use");

        var driver = new Driver
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            License = dto.License,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        await _driverRepository.AddAsync(driver);

        var token = GenerateToken(driver.Id.ToString(), driver.Email, "Driver");
        return new LoginResponseDto
        {
            Id = driver.Id,
            Email = driver.Email,
            Role = "Driver",
            Token = token
        };
    }

    private string GenerateToken(string userId, string email, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "super_secret_key_12345_must_be_long_enough"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}