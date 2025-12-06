using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class ZonasProduccion
{
    [Key]
    public int ZonaId { get; set; }
    [Required(ErrorMessage = "Nombre de la zona requerido")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Provincia requerida")]
    public string Provincia { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "Distancia no valida")]
    public double Distancia { get; set; }
    public string? Referencia { get; set; }
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
