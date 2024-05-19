using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityRecords", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    SecurityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.SecurityQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "HealthReminders",
                columns: table => new
                {
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthReminders", x => x.ReminderId);
                    table.ForeignKey(
                        name: "FK_HealthReminders_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressTrackings",
                columns: table => new
                {
                    ProgressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressTrackings", x => x.ProgressId);
                    table.ForeignKey(
                        name: "FK_ProgressTrackings_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityRecords",
                columns: table => new
                {
                    UserActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityRecords", x => x.UserActivityId);
                    table.ForeignKey(
                        name: "FK_UserActivityRecords_ActivityRecords_ActivityRecordId",
                        column: x => x.ActivityRecordId,
                        principalTable: "ActivityRecords",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActivityRecords_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGoals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGoals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_UserGoals_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthReminders_UserId",
                table: "HealthReminders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressTrackings_UserId",
                table: "ProgressTrackings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityRecords_ActivityRecordId",
                table: "UserActivityRecords",
                column: "ActivityRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityRecords_UserId",
                table: "UserActivityRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGoals_UserId",
                table: "UserGoals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthReminders");

            migrationBuilder.DropTable(
                name: "ProgressTrackings");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.DropTable(
                name: "UserActivityRecords");

            migrationBuilder.DropTable(
                name: "UserGoals");

            migrationBuilder.DropTable(
                name: "ActivityRecords");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
