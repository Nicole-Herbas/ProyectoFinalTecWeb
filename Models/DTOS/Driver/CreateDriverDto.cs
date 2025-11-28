namespace ProyectoFinal.Models.DTOS.Driver
{
    public class CreateDriverDto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string License { get; set; } = default!;
    }
}
