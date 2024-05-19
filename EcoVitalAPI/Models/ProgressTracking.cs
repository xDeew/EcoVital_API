using LoginAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVitalAPI.Models
{
    public class ProgressTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgressId { get; set; }

        [Required]
        [ForeignKey("UserInfo")]
        public int UserId { get; set; }

        public string Metric { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        // Navegación a la entidad UserInfo si la tienes definida
        public virtual UserInfo UserInfo { get; set; }
    }
}
