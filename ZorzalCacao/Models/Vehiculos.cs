using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;
public class Vehiculo
{
    [Key]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "La marca debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^(?=.*[a-zA-Z]).*[a-zA-Z0-9\s-]*$",
    ErrorMessage = "La Marca solo permite letras (A-Z), números (0-9), espacios y guiones (-). Debe contener al menos una letra.")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "El modelo es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El modelo debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9\s-]*$",
        ErrorMessage = "El Modelo solo permite letras (A-Z), números (0-9), espacios y guiones (-).")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La placa es obligatoria")]
    [StringLength(7, MinimumLength = 6, ErrorMessage = "La placa debe tener entre 6 y 7 caracteres alfanuméricos.")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9]{6,7}$",ErrorMessage = "La placa debe contener al menos una letra, al menos un número y solo caracteres alfanuméricos.")]
    public string Placa { get; set; } = string.Empty;

    [Range(1900, 2027,ErrorMessage = "El año debe estar entre 1900 y el año 2027 (inclusive).")]
    public int Anio { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "El color debe tener entre 3 y 30 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]*$",
    ErrorMessage = "El Color solo permite letras (A-Z, incluyendo acentos/ñ/ü) y espacios.")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de vehículo es obligatorio")]
    public string TipoVehiculo { get; set; } = string.Empty;
    public int? ChoferId { get; set; }   
    public Choferes? Chofer { get; set; }  
}

