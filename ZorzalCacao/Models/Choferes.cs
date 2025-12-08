using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;

public class Choferes
{
    [Key]
    public int ChoferId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cédula es obligatoria")]
    public string Cedula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La licencia es obligatoria")]
    public string Licencia { get; set; } = string.Empty;
    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
