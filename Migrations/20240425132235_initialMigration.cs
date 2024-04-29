using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberOfClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    coursesid = table.Column<int>(type: "int", nullable: false),
                    studentsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.coursesid, x.studentsid });
                    table.ForeignKey(
                        name: "FK_CourseStudent_courses_coursesid",
                        column: x => x.coursesid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_studentsid",
                        column: x => x.studentsid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "name", "numberOfClasses" },
                values: new object[,]
                {
                    { 1, "Microsoft Web Services", 32 },
                    { 2, "ASP.NET Core MVC", 44 },
                    { 3, "Introduction To Web Development", 32 }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "firstName", "lastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Mark", "Stone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_studentsid",
                table: "CourseStudent",
                column: "studentsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
