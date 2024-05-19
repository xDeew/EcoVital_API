using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class tablasintermediasreminders02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserReminders",
                columns: table => new
                {
                    UserReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReminders", x => x.UserReminderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReminders");
        }
    }
}
