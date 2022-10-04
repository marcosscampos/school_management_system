using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Grades.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubmissionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<long>(type: "INTEGER", nullable: false),
                    Rate = table.Column<double>(type: "REAL", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 10, 4, 2, 26, 41, 447, DateTimeKind.Local).AddTicks(8951))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");
        }
    }
}
