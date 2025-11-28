namespace ProyectoFinal.Models.DTOS
{
    public class RegisterPasajeroDto
    {
        public string Nombre { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Role { get; set; } = "Pasajero";
    }
}
