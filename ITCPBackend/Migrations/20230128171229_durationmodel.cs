using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCPBackend.Migrations
{
    public partial class durationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "project_durations");

            migrationBuilder.AddColumn<string>(
                name: "FirstEndDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstStartDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondEndDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondStartDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdEndDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdStartDate",
                table: "project_durations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstEndDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "FirstStartDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "SecondEndDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "SecondStartDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "ThirdEndDate",
                table: "project_durations");

            migrationBuilder.DropColumn(
                name: "ThirdStartDate",
                table: "project_durations");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "project_durations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "project_durations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
