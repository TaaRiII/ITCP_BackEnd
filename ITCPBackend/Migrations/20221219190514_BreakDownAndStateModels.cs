using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class BreakDownAndStateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cost_break_down",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cost_break_down", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_strategy_and_state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SustainabilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_strategy_and_state", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cost_break_down");

            migrationBuilder.DropTable(
                name: "project_strategy_and_state");
        }
    }
}
