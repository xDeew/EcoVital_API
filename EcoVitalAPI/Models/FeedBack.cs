using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVitalAPI.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        public string Email { get; set; } // Email del usuario

        [Required]
        public string Type { get; set; } // Tipo de feedback: Sugerencia, Problema técnico, etc.

        [Required]
        public string Message { get; set; } // Mensaje detallado del feedback
    }
}
