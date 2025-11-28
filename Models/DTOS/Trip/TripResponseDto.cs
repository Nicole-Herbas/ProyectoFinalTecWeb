namespace ProyectoFinal.Models.DTOS.Trip;

public class TripResponseDto
{
    public Guid Id { get; set; }
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal EstimatedPrice { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public string PassengerName { get; set; } = string.Empty;
    public string? DriverName { get; set; }
}