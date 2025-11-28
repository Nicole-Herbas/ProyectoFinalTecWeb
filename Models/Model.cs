using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoFinal.Models;

public class Model
{
    [Key]
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }

    [JsonIgnore]
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}