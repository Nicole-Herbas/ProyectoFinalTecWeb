using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS.Vehicle;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehicleResponseDto>> GetAllAsync()
    {
        var vehicles = await _repository.GetAllAsync();
        return vehicles.Select(v => new VehicleResponseDto
        {
            Id = v.Id,
            Plate = v.Plate,
            Color = v.Color,
            Status = v.Status,
            ModelName = v.Model?.Name ?? "Unknown",
            DriverName = v.Driver?.Name ?? "Unassigned"
        });
    }

    public async Task<VehicleResponseDto?> GetByIdAsync(Guid id)
    {
        var v = await _repository.GetByIdAsync(id);
        if (v == null) return null;

        return new VehicleResponseDto
        {
            Id = v.Id,
            Plate = v.Plate,
            Color = v.Color,
            Status = v.Status,
            ModelName = v.Model?.Name ?? "Unknown",
            DriverName = v.Driver?.Name ?? "Unassigned"
        };
    }

    public async Task<VehicleResponseDto> CreateAsync(CreateVehicleDto dto)
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Plate = dto.Plate,
            Color = dto.Color,
            Status = dto.Status,
            ModelId = dto.ModelId,
            DriverId = dto.DriverId
        };

        await _repository.AddAsync(vehicle);

        var created = await _repository.GetByIdAsync(vehicle.Id);
        return new VehicleResponseDto
        {
            Id = created!.Id,
            Plate = created.Plate,
            Color = created.Color,
            Status = created.Status,
            ModelName = created.Model?.Name ?? "Unknown",
            DriverName = created.Driver?.Name ?? "Unassigned"
        };
    }

    public async Task<VehicleResponseDto> UpdateAsync(Guid id, UpdateVehicleDto dto)
    {
        var vehicle = await _repository.GetByIdAsync(id);
        if (vehicle == null) throw new Exception("Vehicle not found");

        vehicle.Color = dto.Color;
        vehicle.Status = dto.Status;

        await _repository.UpdateAsync(vehicle);

        return new VehicleResponseDto
        {
            Id = vehicle.Id,
            Plate = vehicle.Plate,
            Color = vehicle.Color,
            Status = vehicle.Status,
            ModelName = vehicle.Model?.Name ?? "Unknown",
            DriverName = vehicle.Driver?.Name ?? "Unassigned"
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _repository.GetByIdAsync(id);
        if (vehicle != null)
        {
            await _repository.DeleteAsync(vehicle);
        }
    }
}