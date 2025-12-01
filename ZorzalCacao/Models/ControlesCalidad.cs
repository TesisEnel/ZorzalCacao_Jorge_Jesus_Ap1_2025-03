using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZorzalCacao.Models;

public class ControlesCalidad
{
    [Key]
    public int ControlId { get; set; }
    [Range(12, 20, ErrorMessage = "Grado brix no valido")]
    public double GradosBrix { get; set; }
    public string Observaciones { get; set; }
    public string Decision { get; set; } = null!;
    public int RecogidaId { get; set; }
    public Recogidas Recogida { get; set; }

    //empleado
}
