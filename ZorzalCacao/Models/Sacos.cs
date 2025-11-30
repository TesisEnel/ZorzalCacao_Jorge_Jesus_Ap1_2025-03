using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;

public class Sacos
{
    [Key]
    public int SacoId { get; set; }
    public double CantidadPesada { get; set; }
}
