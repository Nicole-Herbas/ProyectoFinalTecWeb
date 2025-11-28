using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS.Trip;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _repository;

    public TripService(ITripRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TripResponseDto>> GetAllAsync()
    {
        var trips = await _repository.GetAllAsync();
        return trips.Select(t => new TripResponseDto
        {
            Id = t.Id,
            Origin = t.Origin,
            Destination = t.Destination,
            EstimatedPrice = t.EstimatedPrice,
            Status = t.Status,
            RequestDate = t.RequestDate,
            PassengerName = t.Passenger?.Name ?? "Unknown",
            DriverName = t.Driver?.Name
        });
    }

    public async Task<TripResponseDto?> GetByIdAsync(Guid id)
    {
        var t = await _repository.GetByIdAsync(id);
        if (t == null) return null;

        return new TripResponseDto
        {
            Id = t.Id,
            Origin = t.Origin,
            Destination = t.Destination,
            EstimatedPrice = t.EstimatedPrice,
            Status = t.Status,
            RequestDate = t.RequestDate,
            PassengerName = t.Passenger?.Name ?? "Unknown",
            DriverName = t.Driver?.Name
        };
    }

    public async Task<TripResponseDto> CreateAsync(CreateTripDto dto)
    {
        var trip = new Trip
        {
            Id = Guid.NewGuid(),
            Origin = dto.Origin,
            Destination = dto.Destination,
            EstimatedPrice = dto.EstimatedPrice,
            PassengerId = dto.PassengerId,
            Status = "Pending",
            RequestDate = DateTime.UtcNow
        };

        await _repository.AddAsync(trip);

        // Fetch again to ensure related data if needed, or mapping directly
        return new TripResponseDto
        {
            Id = trip.Id,
            Origin = trip.Origin,
            Destination = trip.Destination,
            EstimatedPrice = trip.EstimatedPrice,
            Status = trip.Status,
            RequestDate = trip.RequestDate,
            PassengerName = "Passenger" // We can fetch passenger name if needed or optimize later
        };
    }
}