using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class RemoveReminders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthReminders");

            migrationBuilder.DropTable(
                name: "UserReminders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthReminders",
                columns: table => new
                {
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthReminders", x => x.ReminderId);
                });

            migrationBuilder.CreateTable(
                name: "UserReminders",
                columns: table => new
                {
                    UserReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReminders", x => x.UserReminderId);
                });
        }
    }
}
