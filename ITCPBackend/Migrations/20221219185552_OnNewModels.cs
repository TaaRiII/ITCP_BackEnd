using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class OnNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bussinessTypes");

            migrationBuilder.DropTable(
                name: "companyContactPeople");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "fileUploads");

            migrationBuilder.DropTable(
                name: "genComInfos");

            migrationBuilder.DropTable(
                name: "managements");

            migrationBuilder.DropTable(
                name: "serviceCategories");

            migrationBuilder.DropTable(
                name: "shareholders");

            migrationBuilder.CreateTable(
                name: "project_costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_costs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_durations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_durations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_scopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deliverable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Milestone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_scopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MDASector = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project_costs");

            migrationBuilder.DropTable(
                name: "project_details");

            migrationBuilder.DropTable(
                name: "project_durations");

            migrationBuilder.DropTable(
                name: "project_scopes");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.CreateTable(
                name: "bussinessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bussinessTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bussinessTypes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companyContactPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyContactPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUDITED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    ITF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NSITF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PENCOM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileUploads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genComInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEOEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEOPhoneNo = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CoporateHeadQuater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NameOfCEO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactPersonMobile = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RCNumber = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    TelPhone = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genComInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "managements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalSkill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "serviceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shareholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerShares = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shareholders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bussinessTypes_ClientId",
                table: "bussinessTypes",
                column: "ClientId");
        }
    }
}
