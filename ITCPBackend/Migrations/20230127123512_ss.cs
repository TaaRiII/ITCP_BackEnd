using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "project_strategy_and_state");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "project_strategy_and_state");

            migrationBuilder.DropColumn(
                name: "JobState",
                table: "project_strategy_and_state");

            migrationBuilder.AlterColumn<string>(
                name: "SustainabilityName",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "project_strategy_and_state",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "project_strategy_and_state");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "project_strategy_and_state");

            migrationBuilder.AlterColumn<string>(
                name: "SustainabilityName",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CurrentState",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobState",
                table: "project_strategy_and_state",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
