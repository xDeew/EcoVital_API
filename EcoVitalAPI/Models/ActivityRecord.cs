using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVitalAPI.Models
{
    public class ActivityRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        public string Description { get; set; }
        public string ActivityType { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
    }
}
