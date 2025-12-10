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
    public string Zona { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de evento es obligatorio")]
    public string TipoEvento { get; set; } = null!;
    [Required(ErrorMessage = "La intensidad es obligatoria")]
    public string Intensidad { get; set; } = null!;
    public string Observaciones { get; set; } = string.Empty;
    public string EmpleadoId { get; set; }
    public ApplicationUser Empleado { get; set; }
}
