using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZorzalCacao.Models;

public class Fermentaciones
{
    [Key]
    public int FermentacionId { get; set; }
    public double Temperatura { get; set; }
    public string Observaciones { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int RecogidaId { get; set; }
    public Recogidas Recogida { get; set; }
    public ICollection<FermentacionesDetalles> FermentacionesDetalle { get; set; } = new List<FermentacionesDetalles>();
    // empleado
}