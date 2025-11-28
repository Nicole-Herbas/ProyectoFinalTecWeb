using ProyectoFinal.Models.DTOS.Passenger;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services;

public class PassengerService : IPassengerService
{
    private readonly IPassengerRepository _repository;

    public PassengerService(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PassengerResponseDto>> GetAllAsync()
    {
        var passengers = await _repository.GetAllAsync();
        return passengers.Select(p => new PassengerResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Email = p.Email,
            Phone = p.Phone
        });
    }

    public async Task<PassengerResponseDto?> GetByIdAsync(Guid id)
    {
        var p = await _repository.GetByIdAsync(id);
        if (p == null) return null;

        return new PassengerResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Email = p.Email,
            Phone = p.Phone
        };
    }

    public async Task<PassengerResponseDto> UpdateAsync(Guid id, UpdatePassengerDto dto)
    {
        var passenger = await _repository.GetByIdAsync(id);
        if (passenger == null) throw new Exception("Passenger not found");

        passenger.Name = dto.Name;
        passenger.Phone = dto.Phone;

        await _repository.UpdateAsync(passenger);

        return new PassengerResponseDto
        {
            Id = passenger.Id,
            Name = passenger.Name,
            Email = passenger.Email,
            Phone = passenger.Phone
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var passenger = await _repository.GetByIdAsync(id);
        if (passenger != null)
        {
            await _repository.DeleteAsync(passenger);
        }
    }
}