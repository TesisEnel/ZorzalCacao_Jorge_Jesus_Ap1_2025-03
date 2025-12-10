using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class Fermentaciones
{
    [Key]
    public int FermentacionId { get; set; }

    [Range(50, 100, ErrorMessage = "Temperatura no válida. Debe estar entre 50°F y 100°F")]
    public double Temperatura { get; set; }

    [StringLength(500, ErrorMessage = "Las Observaciones no pueden exceder los 500 caracteres.")]
    public string Observaciones { get; set; } = string.Empty;

    [Required(ErrorMessage = "La Fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una recogida")]
    public int RecogidaId { get; set; }
    public Recogidas Recogida { get; set; }

    [Required(ErrorMessage = "Por favor, seleccione un empleado")]
    public string EmpleadoId { get; set; }
    public ApplicationUser Empleado { get; set; }
    public ICollection<FermentacionesDetalles> FermentacionesDetalle { get; set; } = new List<FermentacionesDetalles>();
}