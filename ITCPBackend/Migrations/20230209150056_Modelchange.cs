using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class Modelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deliverable",
                table: "project_scopes");

            migrationBuilder.DropColumn(
                name: "Milestone",
                table: "project_scopes");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "project_scopes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "project_scopes");

            migrationBuilder.AddColumn<string>(
                name: "Deliverable",
                table: "project_scopes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Milestone",
                table: "project_scopes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
