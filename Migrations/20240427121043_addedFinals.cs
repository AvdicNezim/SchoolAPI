using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    public partial class addedFinals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mark = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Finals_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Finals_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "id", "courseId", "date", "mark", "name", "studentId" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 1 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "id", "courseId", "date", "mark", "name", "studentId" },
                values: new object[] { 2, 1, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 2 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "id", "courseId", "date", "mark", "name", "studentId" },
                values: new object[] { 3, 2, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Finals_courseId",
                table: "Finals",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Finals_studentId",
                table: "Finals",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finals");
        }
    }
}
