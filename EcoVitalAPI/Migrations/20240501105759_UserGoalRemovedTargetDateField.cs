using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class UserGoalRemovedTargetDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetDate",
                table: "UserGoals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TargetDate",
                table: "UserGoals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
