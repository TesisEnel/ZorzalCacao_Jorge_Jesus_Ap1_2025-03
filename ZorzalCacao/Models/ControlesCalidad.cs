using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZorzalCacao.Models;

public class ControlesCalidad
{
    [Key]
    public int ControlId { get; set; }
    public double GradosBrix { get; set; }
    public string Observaciones { get; set; }
    public string Decision { get; set; }
    public int RecogidaId { get; set; }
    public Recogidas Recogida { get; set; }

    //empleado
}
