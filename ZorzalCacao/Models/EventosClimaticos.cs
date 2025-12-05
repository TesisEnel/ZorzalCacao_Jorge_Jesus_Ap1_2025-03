using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models
{
    public class EventosClimaticos
    {
        [Key]
        public int EventoClimaticoId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La zona es requerida")]
        public string Zona { get; set; }

        [Required(ErrorMessage = "El tipo de evento es requerido")]
        public string TipoEvento { get; set; }
        [Required(ErrorMessage = "La intensidad es requerida")]
        public string Intensidad { get; set; } // leve, moderada, fuerte
        public string Observaciones { get; set; }

    }
}
