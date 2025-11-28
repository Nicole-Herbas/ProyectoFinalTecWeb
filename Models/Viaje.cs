using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Viaje
    {
        public Guid Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        //Relacion con Pasajero 1:M

        public Guid PasajeroId { get; set; }

        public Pasajero? Pasajero { get; set; } = default!;

        //Relacion con Conductor 1:M

        public Guid ConductorId { get; set; }
        public Conductor? Conductor { get; set; } = default!;

    }
}
