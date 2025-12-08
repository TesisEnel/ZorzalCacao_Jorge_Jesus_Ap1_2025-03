using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;
public class Vehiculo
{
    [Key]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "La marca debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9\s-]*$", ErrorMessage = "La marca contiene caracteres no válidos.")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "El modelo es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El modelo debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9\s-]*$", ErrorMessage = "El modelo contiene caracteres no válidos.")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La placa es obligatoria")]
    [StringLength(7, MinimumLength = 6, ErrorMessage = "La placa debe tener entre 6 y 7 caracteres alfanuméricos.")] // Ajustado a un largo común
    [RegularExpression(@"^[a-zA-Z0-9]{6,7}$", ErrorMessage = "La placa solo debe contener letras y números (sin guiones ni espacios).")]
    public string Placa { get; set; } = string.Empty;

    [Range(1980, 2100, ErrorMessage = "El año debe ser válido")]
    public int Anio { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "El color debe tener entre 3 y 30 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]*$", ErrorMessage = "El color contiene caracteres no válidos.")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de vehículo es obligatorio")]
    public string TipoVehiculo { get; set; } = string.Empty;
    public int? ChoferId { get; set; }   
    public Choferes? Chofer { get; set; }  
}

