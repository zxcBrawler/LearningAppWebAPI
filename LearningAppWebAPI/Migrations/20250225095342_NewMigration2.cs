using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_CourseId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Lesson");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Course_Id",
                table: "Lesson",
                column: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_Course_Id",
                table: "Lesson",
                column: "Course_Id",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_Course_Id",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_Course_Id",
                table: "Lesson");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CourseId",
                table: "Lesson",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
