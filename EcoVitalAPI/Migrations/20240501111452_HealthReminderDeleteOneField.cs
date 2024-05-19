using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class HealthReminderDeleteOneField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthReminders_UserInfos_UserId",
                table: "HealthReminders");

            migrationBuilder.DropIndex(
                name: "IX_HealthReminders_UserId",
                table: "HealthReminders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HealthReminders_UserId",
                table: "HealthReminders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthReminders_UserInfos_UserId",
                table: "HealthReminders",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
