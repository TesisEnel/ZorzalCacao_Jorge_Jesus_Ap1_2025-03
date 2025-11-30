using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;

public class Remociones
{
    [Key]
    public int RemocionId { get; set; }
    public int NumeroRemocion { get; set; }
    public double Cantidad { get; set; }
}
