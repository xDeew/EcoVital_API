using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoVitalAPI.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DbSet<ProgressTracking> ProgressTrackings { get; set; }

        public DbSet<UserGoal> UserGoals { get; set; }


        public DbSet<UserActivityRecord> UserActivityRecords { get; set; }

        public DbSet<ActivityRecord> ActivityRecords { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
    }
}
