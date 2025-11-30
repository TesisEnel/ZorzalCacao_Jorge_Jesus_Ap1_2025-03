using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZorzalCacao.Models;

public class FermentacionesDetalles
{
    [Key]
    public int DetalleId { get; set; }
    public int FermentacionId { get; set; }
    public int RemocionId { get; set; }
    public int Cantidad { get; set; }
    public double Temperatura { get; set; }
    public DateTime FechaFermentacion { get; set; } = DateTime.Now;

    [ForeignKey(nameof(FermentacionId))]
    public virtual Fermentaciones Fermentacion { get; set; }

    [ForeignKey(nameof(RemocionId))]
    public virtual Remociones Remocion { get; set; }
    // empleado
}
