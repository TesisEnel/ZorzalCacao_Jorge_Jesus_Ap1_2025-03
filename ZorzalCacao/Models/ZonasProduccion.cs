using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class ZonasProduccion
{
    [Key]
    public int ZonaId { get; set; }

    [Required(ErrorMessage = "Nombre de la zona requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Provincia requerida")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La provincia debe tener entre 3 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s.-]*$", ErrorMessage = "La provincia contiene caracteres no válidos.")]
    public string Provincia { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "Distancia no valida")]
    public double Distancia { get; set; }
    public string Referencia { get; set; } = string.Empty;
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
