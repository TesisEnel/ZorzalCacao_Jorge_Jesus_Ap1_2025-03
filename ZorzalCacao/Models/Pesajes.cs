using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class Pesajes
{
    [Key]
    public int PesajeId { get; set; }
    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    //public string EmpleadoId { get; set; }
    //public ApplicationUser Empleado { get; set; }
    public ICollection<PesajesDetalles> PesajesDetalle { get; set; } = new List<PesajesDetalles>();     
}
