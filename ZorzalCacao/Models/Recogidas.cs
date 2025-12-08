using System.ComponentModel.DataAnnotations;
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
    public string CertificacionProducto { get; set; } = string.Empty;
    public string EstadoEntrega { get; set; } = "Pendiente";

    [Range(0.01, double.MaxValue, ErrorMessage = "Cantidad de sacos no valida")]
    public double CantidadSacos { get; set; }

    [Required(ErrorMessage = "Por favor, seleccione un chofer")]
    public int? ChoferId { get; set; }
    public Choferes? Chofer { get; set; }

    [Required(ErrorMessage ="Por favor, seleccione un productor")]
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
