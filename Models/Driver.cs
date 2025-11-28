using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoFinal.Models;

public class Driver
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Trip> Trips { get; set; } = new List<Trip>();

    [JsonIgnore]
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
