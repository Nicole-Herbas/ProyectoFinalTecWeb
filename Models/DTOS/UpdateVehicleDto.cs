namespace Security.Models.DTOS
{
    public class UpdateVehicleDto
    {
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string Plate { get; set; } = default!;
        public int Year { get; set; }
        public Guid DriverId { get; set; }
        public string Status { get; set; } = "Activo";
    }
}
