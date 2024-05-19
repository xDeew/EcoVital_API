
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoVitalAPI.Models
{
    public class UserActivityRecord
    {
        [Key]
        public int UserActivityId { get; set; }

        // Estas son las llaves foráneas que hacen referencia a las respectivas tablas
        public int UserId { get; set; }
        public int ActivityRecordId { get; set; }

        // Propiedades de navegación son opcionales
        // Si las incluyes, asegúrate de que se manejen correctamente en los métodos de tu API
        //public virtual UserInfo UserInfo { get; set; }
        //public virtual ActivityRecord ActivityRecord { get; set; }
    }
}
