using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    public partial class UserGoalUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivityRecords_ActivityRecords_ActivityRecordId",
                table: "UserActivityRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivityRecords_UserInfos_UserId",
                table: "UserActivityRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGoals_UserInfos_UserId",
                table: "UserGoals");

            migrationBuilder.DropIndex(
                name: "IX_UserGoals_UserId",
                table: "UserGoals");

            migrationBuilder.DropIndex(
                name: "IX_UserActivityRecords_ActivityRecordId",
                table: "UserActivityRecords");

            migrationBuilder.DropIndex(
                name: "IX_UserActivityRecords_UserId",
                table: "UserActivityRecords");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserGoals");

            migrationBuilder.DropColumn(
                name: "GoalType",
                table: "UserGoals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserGoals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoalType",
                table: "UserGoals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserGoals_UserId",
                table: "UserGoals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityRecords_ActivityRecordId",
                table: "UserActivityRecords",
                column: "ActivityRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityRecords_UserId",
                table: "UserActivityRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityRecords_ActivityRecords_ActivityRecordId",
                table: "UserActivityRecords",
                column: "ActivityRecordId",
                principalTable: "ActivityRecords",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityRecords_UserInfos_UserId",
                table: "UserActivityRecords",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGoals_UserInfos_UserId",
                table: "UserGoals",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
