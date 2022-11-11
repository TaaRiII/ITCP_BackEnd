using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class seventhagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    BPP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PENCOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NSITF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AUDITED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileUploads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileUploads");
        }
    }
}
