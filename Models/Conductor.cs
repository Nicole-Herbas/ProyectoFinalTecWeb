namespace ProyectoFinal.Models
{
    public class Conductor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; } = string.Empty;
        public string Telefono { get; set; }

        public string Email { get; set; } = string.Empty;

        // 1:N Conductor -> Viajes
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();

        // N:M Conductor <-> Vehiculos
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    }
}
