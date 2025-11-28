using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models;

public class Trip
{
    [Key]
    public Guid Id { get; set; }
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal EstimatedPrice { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }

    public Guid PassengerId { get; set; }
    [ForeignKey("PassengerId")]
    public Passenger? Passenger { get; set; }

    public Guid? DriverId { get; set; }
    [ForeignKey("DriverId")]
    public Driver? Driver { get; set; }
}