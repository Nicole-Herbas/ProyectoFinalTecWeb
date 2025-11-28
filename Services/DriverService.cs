using ProyectoFinal.Models.DTOS.Driver;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _repository;

    public DriverService(IDriverRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DriverResponseDto>> GetAllAsync()
    {
        var drivers = await _repository.GetAllAsync();
        return drivers.Select(d => new DriverResponseDto
        {
            Id = d.Id,
            Name = d.Name,
            Email = d.Email,
            Phone = d.Phone,
            License = d.License
        });
    }

    public async Task<DriverResponseDto?> GetByIdAsync(Guid id)
    {
        var d = await _repository.GetByIdAsync(id);
        if (d == null) return null;

        return new DriverResponseDto
        {
            Id = d.Id,
            Name = d.Name,
            Email = d.Email,
            Phone = d.Phone,
            License = d.License
        };
    }

    public async Task<DriverResponseDto> UpdateAsync(Guid id, UpdateDriverDto dto)
    {
        var driver = await _repository.GetByIdAsync(id);
        if (driver == null) throw new Exception("Driver not found");

        driver.Name = dto.Name;
        driver.Phone = dto.Phone;
        driver.License = dto.License;

        await _repository.UpdateAsync(driver);

        return new DriverResponseDto
        {
            Id = driver.Id,
            Name = driver.Name,
            Email = driver.Email,
            Phone = driver.Phone,
            License = driver.License
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var driver = await _repository.GetByIdAsync(id);
        if (driver != null)
        {
            await _repository.DeleteAsync(driver);
        }
    }
}