using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class ControlesCalidad
{
    [Key]
    public int ControlId { get; set; }
    [Range(12, 20, ErrorMessage = "Rango no valido. Debe estar entre 12°Bx y 20°Bx")]
    public double GradosBrix { get; set; }
    public string Observaciones { get; set; } = string.Empty;
    public string Decision { get; set; } = null!;

    [Required(ErrorMessage = "Por favor, seleccione una recogida")]
    public int RecogidaId { get; set; }
    public Recogidas Recogida { get; set; }
    public string EmpleadoId { get; set; }
    public ApplicationUser Empleado { get; set; }
}
