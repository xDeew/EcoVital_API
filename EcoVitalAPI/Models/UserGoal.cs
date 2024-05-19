using LoginAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserGoal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GoalId { get; set; }

    public bool IsAchieved { get; set; }

    [ForeignKey("UserInfo")]
    public int UserId { get; set; }
    public int ActivityRecordId { get;  set; }


}