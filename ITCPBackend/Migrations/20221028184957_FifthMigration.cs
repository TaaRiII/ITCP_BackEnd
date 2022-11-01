using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bussinessTypes_clients_ClientId",
                table: "bussinessTypes");

            migrationBuilder.DropIndex(
                name: "IX_bussinessTypes_ClientId",
                table: "bussinessTypes");
        }
    }
}
