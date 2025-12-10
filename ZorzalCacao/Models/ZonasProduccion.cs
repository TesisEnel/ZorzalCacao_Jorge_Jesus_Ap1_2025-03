using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class ZonasProduccion
{
    [Key]
    public int ZonaId { get; set; }

    [Required(ErrorMessage = "Nombre de la zona requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    [RegularExpression(@"^(?=.*[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]).*[a-zA-Z0-9áéíóúÁÉÍÓÚñÑüÜ\s-]*$",
        ErrorMessage = "El nombre de la zona debe contener al menos una letra y solo permite caracteres alfanuméricos, espacios y guiones (-).")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Provincia requerida")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La provincia debe tener entre 3 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s.-]*$",
    ErrorMessage = "La Provincia solo permite letras (A-Z, incluyendo acentos/ñ), espacios, puntos (.) y guiones (-). No se permiten números ni otros símbolos.")]
    public string Provincia { get; set; } = null!;

    [Range(0.01, 450,
    ErrorMessage = "Distancia no válida. El valor debe estar entre 0.01 km y 450 km.")]
    public double Distancia { get; set; }

    [StringLength(250,ErrorMessage = "La Referencia no puede exceder los 250 caracteres.")]
    public string Referencia { get; set; } = string.Empty;
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
