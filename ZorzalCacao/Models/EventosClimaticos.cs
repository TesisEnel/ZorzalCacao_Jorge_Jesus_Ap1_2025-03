using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class EventosClimaticos
{
    [Key]
    public int EventoClimaticoId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "La zona es obligatoria")]
    [StringLength(50, MinimumLength = 2,ErrorMessage = "La zona debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^(?=.*[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]).*$",
        ErrorMessage = "La zona debe contener al menos una letra (no puede ser solo números o solo espacios).")]
    public string Zona { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de evento es obligatorio")]
    public string TipoEvento { get; set; } = null!;
    [Required(ErrorMessage = "La intensidad es obligatoria")]
    public string Intensidad { get; set; } = null!;

    [StringLength(500,ErrorMessage = "Las Observaciones no pueden exceder los 500 caracteres.")]
    public string Observaciones { get; set; } = string.Empty;
    public string EmpleadoId { get; set; }
    public ApplicationUser Empleado { get; set; }
}
