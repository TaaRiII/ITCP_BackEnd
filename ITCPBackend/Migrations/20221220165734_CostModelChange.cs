using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class CostModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "cost_break_down");

            migrationBuilder.AddColumn<string>(
                name: "CostDescription",
                table: "project_costs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDescription",
                table: "project_costs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "cost_break_down",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
