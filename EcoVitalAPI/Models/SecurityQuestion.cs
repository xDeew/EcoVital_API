using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAPI.Models
{
    public class SecurityQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SecurityQuestionId { get; set; } 

        [ForeignKey("UserInfo")]
        public int UserId { get; set; } 

        public string QuestionText { get; set; }
        public string Answer { get; set; }


    }
}
