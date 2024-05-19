using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class tablaIntermediaUserReminders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HealthReminders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HealthReminders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
