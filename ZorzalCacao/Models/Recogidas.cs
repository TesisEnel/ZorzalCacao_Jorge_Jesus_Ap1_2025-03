using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class Recogidas
{
    [Key]
    public int RecogidaId { get; set; }

    [Required(ErrorMessage = "Fecha requerida")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Punto de encuentro requerido")]
    public string PuntoEncuentro { get; set; } = null!;
    public List<string> CertificacionesProducto { get; set; } = new List<string>();
    public string EstadoEntrega { get; set; } = "Pendiente";

    [Required(ErrorMessage = "Cantidad de sacos requerida")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Cantidad de sacos no valida")]
    public double CantidadSacos { get; set; }

    [Required(ErrorMessage = "Por favor, seleccione un chofer")]
    public int? ChoferId { get; set; }
    public Choferes? Chofer { get; set; }

    [Required(ErrorMessage ="Por favor, seleccione un productor")]
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
