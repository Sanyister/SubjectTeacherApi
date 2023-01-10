using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zsoow6TeacherSubjApi.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Semesters_SemesterId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Students_StudentId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Subjects_SubjectId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Semesters_SemesterId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Subjects_SubjectId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Teachers_TeacherId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Students_StudentId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Semesters_semesterId",
                table: "SubjectTimetable");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Subjects_SubjectId",
                table: "SubjectTimetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Titles_titleId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Titles",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Titles",
                newName: "Title");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_titleId",
                table: "Teacher",
                newName: "IX_Teacher_titleId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_StudentId",
                table: "Subject",
                newName: "IX_Subject_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_SemesterId",
                table: "Subject",
                newName: "IX_Subject_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Student",
                newName: "IX_Student_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Title",
                table: "Title",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Semester_SemesterId",
                table: "SemesterStudent",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Student_StudentId",
                table: "SemesterStudent",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Subject_SubjectId",
                table: "SemesterStudent",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Semester_SemesterId",
                table: "SemesterTeacher",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Subject_SubjectId",
                table: "SemesterTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Teacher_TeacherId",
                table: "SemesterTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Semester_SemesterId",
                table: "Subject",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Student_StudentId",
                table: "Subject",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Semester_semesterId",
                table: "SubjectTimetable",
                column: "semesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Subject_SubjectId",
                table: "SubjectTimetable",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Title_titleId",
                table: "Teacher",
                column: "titleId",
                principalTable: "Title",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Semester_SemesterId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Student_StudentId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterStudent_Subject_SubjectId",
                table: "SemesterStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Semester_SemesterId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Subject_SubjectId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterTeacher_Teacher_TeacherId",
                table: "SemesterTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Semester_SemesterId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Student_StudentId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Semester_semesterId",
                table: "SubjectTimetable");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Subject_SubjectId",
                table: "SubjectTimetable");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Title_titleId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Title",
                table: "Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Title",
                newName: "Titles");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_titleId",
                table: "Teachers",
                newName: "IX_Teachers_titleId");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_StudentId",
                table: "Subjects",
                newName: "IX_Subjects_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_SemesterId",
                table: "Subjects",
                newName: "IX_Subjects_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_DepartmentId",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Titles",
                table: "Titles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Semesters_SemesterId",
                table: "SemesterStudent",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Students_StudentId",
                table: "SemesterStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterStudent_Subjects_SubjectId",
                table: "SemesterStudent",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Semesters_SemesterId",
                table: "SemesterTeacher",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Subjects_SubjectId",
                table: "SemesterTeacher",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterTeacher_Teachers_TeacherId",
                table: "SemesterTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Students_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Semesters_semesterId",
                table: "SubjectTimetable",
                column: "semesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Subjects_SubjectId",
                table: "SubjectTimetable",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Titles_titleId",
                table: "Teachers",
                column: "titleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
