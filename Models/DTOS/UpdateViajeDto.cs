using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS
{
    public class UpdateViajeDto
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Precio { get; set; }
    }
}
