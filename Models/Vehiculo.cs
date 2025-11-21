using ProyectoFinal.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Security.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(80)]
        public string Brand { get; set; } = default!;   // marca

        [Required, MaxLength(80)]
        public string Model { get; set; } = default!;   // modelo

        [Required, MaxLength(15)]
        public string Plate { get; set; } = default!;   // placa

        [Range(1980, 2100)]
        public int Year { get; set; }                   // año

        [Required]
        public Guid DriverId { get; set; }              // FK → User (Conductor)
        public User? Driver { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Activo";  // Activo / Inactivo
    }
}
