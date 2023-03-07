using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class RemoveminsitryColumnforuserandaddinclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Minisitry",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Minisitry",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Minisitry",
                table: "clients");

            migrationBuilder.AddColumn<string>(
                name: "Minisitry",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
