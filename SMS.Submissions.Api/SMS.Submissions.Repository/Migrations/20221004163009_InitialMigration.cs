using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Submissions.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<long>(type: "INTEGER", nullable: false),
                    ClassRoomId = table.Column<long>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<long>(type: "INTEGER", nullable: false),
                    GradeId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 10, 4, 13, 30, 9, 589, DateTimeKind.Local).AddTicks(4980))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submission");
        }
    }
}
