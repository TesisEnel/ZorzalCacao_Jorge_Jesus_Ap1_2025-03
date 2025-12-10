using System.ComponentModel.DataAnnotations;
using ZorzalCacao.Data;

namespace ZorzalCacao.Models;

public class Recogidas
{
    [Key]
    public int RecogidaId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El punto de encuentro es obligatorio")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "El Punto de Encuentro debe tener entre 5 y 100 caracteres.")]
    [RegularExpression(@"^(?=.*[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]).*$",
        ErrorMessage = "El Punto de Encuentro debe contener al menos una letra (no puede ser solo números o solo espacios).")]
    public string PuntoEncuentro { get; set; } = null!;
    public string CertificacionProducto { get; set; } = string.Empty;
    public string EstadoEntrega { get; set; } = "Pendiente";

    [Range(0.5, 1000,ErrorMessage = "La cantidad de sacos debe ser un valor entre 0.5 (medio saco) y 1000.")]
    public double CantidadSacos { get; set; }

    [Required(ErrorMessage = "Por favor, seleccione un chofer")]
    public int? ChoferId { get; set; }
    public Choferes? Chofer { get; set; }

    [Required(ErrorMessage ="Por favor, seleccione un productor")]
    public string ProductorId { get; set; }
    public ApplicationUser Productor { get; set; }
}
