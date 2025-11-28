namespace ProyectoFinal.Models.DTOS.Vehicle;

public class VehicleResponseDto
{
    public Guid Id { get; set; }
    public string Plate { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public string DriverName { get; set; } = string.Empty;
}