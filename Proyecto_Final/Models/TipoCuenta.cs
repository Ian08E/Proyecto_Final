using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Manejo_Presupuesto.Models
{
    public class TipoCuenta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido para continuar")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

    }
}
