namespace ProyectoFinal.Models.DTOS
{
    public class UpdatePasajeroDto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
