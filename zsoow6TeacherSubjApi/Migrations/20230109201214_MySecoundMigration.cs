using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zsoow6TeacherSubjApi.Migrations
{
    public partial class MySecoundMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubjectTimetable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semesterId = table.Column<int>(type: "int", nullable: false),
                    timetable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTimetable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTimetable_Semesters_semesterId",
                        column: x => x.semesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTimetable_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTimetable_semesterId",
                table: "SubjectTimetable",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTimetable_SubjectId",
                table: "SubjectTimetable",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTimetable");
        }
    }
}
