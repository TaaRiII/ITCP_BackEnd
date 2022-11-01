using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bussinessTypes_clients_ClientId",
                table: "bussinessTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_clients_ClientId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_ClientId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_bussinessTypes_ClientId",
                table: "bussinessTypes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_ClientId",
                table: "clients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_bussinessTypes_ClientId",
                table: "bussinessTypes",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_bussinessTypes_clients_ClientId",
                table: "bussinessTypes",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_clients_ClientId",
                table: "clients",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");
        }
    }
}
