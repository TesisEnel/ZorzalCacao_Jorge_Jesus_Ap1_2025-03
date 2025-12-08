using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;

public class Choferes
{
    [Key]
    public int ChoferId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]*$", ErrorMessage = "El nombre contiene caracteres no válidos.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]*$", ErrorMessage = "El apellido contiene caracteres no válidos.")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cédula es obligatoria")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "La cédula debe tener exactamente 11 dígitos.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe contener solo 11 dígitos numéricos.")]
    public string Cedula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe contener solo 10 dígitos numéricos.")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La licencia es obligatoria")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "La licencia debe tener entre 8 y 15 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9\s-]*$", ErrorMessage = "La licencia contiene caracteres no válidos.")]
    public string Licencia { get; set; } = string.Empty;
    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
