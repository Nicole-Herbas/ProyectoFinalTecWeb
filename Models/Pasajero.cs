namespace ProyectoFinal.Models
{
    public class Pasajero
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // 1:N Pasajero -> Viajes
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
