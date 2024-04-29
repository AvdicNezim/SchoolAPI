using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    public partial class addedDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Microsoft Web Development" });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Microsoft Desktop Development" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "departmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "departmentId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_students_departmentId",
                table: "students",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_departmentId",
                table: "students",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_departmentId",
                table: "students");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropIndex(
                name: "IX_students_departmentId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "students");
        }
    }
}
