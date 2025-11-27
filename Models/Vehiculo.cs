using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public Guid Id { get; set; }
       
        [Required]
        [MaxLength(15)]
        public string Placa { get; set; } = default!;

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = "Activo"; // Activo / Inactivo

        // Relación N:M Vehiculo -> Conductor
        public Guid ConductorId { get; set; }
        public Conductor Conductor { get; set; } = default!;

        // Relación 1:1 Vehiculo -> Modelo
        public Modelo Modelo { get; set; } = default!;

    }
}