namespace Aplicacion_Perros.Models
{
    public class Donaciones
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string ?OrganizacionBeneficiaria { get; set; }
        public DateTime Fecha { get; set; }
    }
}