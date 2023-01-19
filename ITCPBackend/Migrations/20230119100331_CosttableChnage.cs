using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class CosttableChnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDescription",
                table: "project_costs");

            migrationBuilder.AddColumn<string>(
                name: "CostDetails",
                table: "project_costs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDetails",
                table: "project_costs");

            migrationBuilder.AddColumn<string>(
                name: "CostDescription",
                table: "project_costs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
