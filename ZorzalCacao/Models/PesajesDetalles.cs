using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class PesajesDetalles
{
    [Key]
    public int DetalleId { get; set; }
    public int PesajeId { get; set; }
    public int SacoId { get; set; }
    public double Cantidad { get; set; }
    public double Peso { get; set; }

    [ForeignKey(nameof(PesajeId))]
    public virtual Pesajes Pesaje { get; set; }

    [ForeignKey(nameof(SacoId))]
    public virtual Sacos Saco { get; set; }
}
